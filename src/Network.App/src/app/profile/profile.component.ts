import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { ProfileService } from '@api';
import { NavigationService } from '@core';
import { of } from 'rxjs';
import { map, startWith, switchMap, tap } from 'rxjs/operators';

export enum ProfileState {
  Edit,
  Create,
  View
}

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss']
})
export class ProfileComponent  {

  public readonly avatarFormControl = new FormControl(null, []);

  private get initialVm$() {
    return this._activatedRoute.paramMap
    .pipe(
      map(paramMap => {
        if(paramMap.get("profileId")) {
          return { state: ProfileState.View, profileId: paramMap.get("profileId") };
        }

        if(paramMap.get("editProfileId")) {
          return { state: ProfileState.Edit, profileId: paramMap.get("editProfileId") };
        }

        return { state: ProfileState.Create, profileId: "" };
      })
    )
  }
  public form: FormGroup = new FormGroup({
    firstname: new FormControl(null, []),
    lastnmae: new FormControl(null, []),
    email: new FormControl(null, []),
    githubProfile: new FormControl(null, []),
    linkedInProfile: new FormControl(null, [])
  });

  public ProfileState: typeof ProfileState = ProfileState;

  public readonly vm$ = this.initialVm$
  .pipe(
    switchMap(vm => {
      if(vm.state == ProfileState.Edit || vm.state == ProfileState.View) {
        return this._profileService.getById(vm)
        .pipe(
          map(profile => Object.assign(vm, { profile })),
          tap(vm => this.avatarFormControl.patchValue(vm.profile.avatarDigitalAssetId))
        );
      }
      return of(Object.assign(vm, { profile: null }));
    }),
    switchMap(vm => this.avatarFormControl
      .valueChanges
      .pipe(
        switchMap(avatarDigitalAssetId => {
          Object.assign(vm.profile, { avatarDigitalAssetId });
          return this._profileService.update({ profile: vm.profile });
        }),
        map(_ => vm),
        startWith(vm)
        )
        )
  );

  constructor(
    private readonly _activatedRoute: ActivatedRoute,
    private readonly _profileService: ProfileService,
    private readonly _navigationService: NavigationService
  ) { }

  public handleEditClick(vm) {
    vm.state = ProfileState.Edit;
  }

  public handleSaveClick(vm) {
    vm.state = ProfileState.View;
  }

  public back() {
    this._navigationService.back();
  }
}
