import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { ProfileService } from '@api';
import { NavigationService } from '@core';
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

  public form: FormGroup = new FormGroup({
    firstname: new FormControl(null, []),
    lastnmae: new FormControl(null, []),
    email: new FormControl(null, []),
    githubProfile: new FormControl(null, []),
    linkedInProfile: new FormControl(null, [])
  });

  public state: ProfileState = ProfileState.View;

  public ProfileState: typeof ProfileState = ProfileState;

  public readonly vm$ = this._activatedRoute.paramMap
  .pipe(
    switchMap(paramMap => this._profileService.getById({ profileId: paramMap.get("id") })),
    tap(profile => this.avatarFormControl.patchValue(profile.avatarDigitalAssetId)),
    switchMap(profile => this.avatarFormControl
      .valueChanges
      .pipe(
        switchMap(avatarDigitalAssetId => {
          Object.assign(profile, { avatarDigitalAssetId });
          return this._profileService.update({ profile });
        }),
        map(_ => profile),
        startWith(profile)
        )
        ),
    map(profile => ({ profile }))
  );

  constructor(
    private readonly _activatedRoute: ActivatedRoute,
    private readonly _profileService: ProfileService,
    private readonly _navigationService: NavigationService
  ) { }

  public handleEditClick() {
    this.state = ProfileState.Edit;
  }

  public handleSaveClick() {
    this.state = ProfileState.View;
  }

  public back() {
    this._navigationService.back();
  }

}
