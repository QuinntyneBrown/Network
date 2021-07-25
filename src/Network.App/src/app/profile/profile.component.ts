import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ProfileService } from '@api';
import { NavigationService } from '@core';
import { of, Subject } from 'rxjs';
import { map, startWith, switchMap, takeUntil, tap } from 'rxjs/operators';

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

  private readonly _destroyed$: Subject<void> = new Subject();

  private get initialVm$() {
    let vm = {
      state: ProfileState.Create,
      profileId: null,
      form: new FormGroup({
        profileId: new FormControl(null,[]),
        firstname: new FormControl(null, []),
        lastname: new FormControl(null, []),
        email: new FormControl(null, []),
        githubProfile: new FormControl(null, []),
        linkedInProfile: new FormControl(null, []),
        avatarDigitalAssetId: new FormControl(null, [])
      }),
      avatarFormControl: new FormControl(null,[])
    };

    return this._activatedRoute.paramMap
    .pipe(
      map(paramMap => {
        if(paramMap.get("profileId")) {
          return Object.assign(vm,{ state: ProfileState.View, profileId: paramMap.get("profileId") });
        }

        if(paramMap.get("editProfileId")) {
          return Object.assign(vm, { state: ProfileState.Edit, profileId: paramMap.get("editProfileId") });
        }

        return vm;
      })
    )
  }

  public ProfileState: typeof ProfileState = ProfileState;

  public readonly vm$ = this.initialVm$
  .pipe(
    switchMap(vm => {
      if(vm.state == ProfileState.Edit || vm.state == ProfileState.View) {
        return this._profileService.getById(vm)
        .pipe(
          map(profile => Object.assign(vm, { profile })),
          tap(vm => {
            vm.avatarFormControl.patchValue(vm.profile?.avatarDigitalAssetId);
            vm.form.patchValue(vm.profile)
          })
        );
      }
      return of(Object.assign(vm, { profile: null }));
    }),
    switchMap(vm => vm.avatarFormControl
      .valueChanges
      .pipe(
        switchMap(avatarDigitalAssetId => {
          Object.assign(vm.profile, { avatarDigitalAssetId });
          vm.form.patchValue({ avatarDigitalAssetId });

          if(vm.state == ProfileState.Edit || vm.state == ProfileState.View) {
            return this._profileService.updateAvatar({ profile: vm.profile });
          }

          return of(null);
        }),
        map(_ => vm),
        startWith(vm)
        )
        )
  );

  constructor(
    private readonly _activatedRoute: ActivatedRoute,
    private readonly _profileService: ProfileService,
    private readonly _navigationService: NavigationService,
    private readonly _router: Router
  ) { }

  public handleEditClick(vm) {
    this._router.navigate(["/","profile","edit", vm.profile.profileId])
  }

  public handleCancelClick() {
    this._navigationService.back();
  }

  public handleSaveClick(vm) {
    const obs$ = vm.state == ProfileState.Edit
    ? this._profileService.update({ profile: vm.form.value })
    :this._profileService.create({ profile: vm.form.value })

    obs$
    .pipe(
      takeUntil(this._destroyed$),
      tap(response => this._router.navigate(["/", "profile", response.profile.profileId]))
    )
    .subscribe();
  }

  public back() {
    this._navigationService.back();
  }
}
