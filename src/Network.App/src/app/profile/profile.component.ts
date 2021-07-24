import { Component } from '@angular/core';
import { FormControl } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { ProfileService } from '@api';
import { Subject } from 'rxjs';
import { map, startWith, switchMap, tap } from 'rxjs/operators';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss']
})
export class ProfileComponent  {

  private readonly _destroyed: Subject<void> = new Subject();

  public avatarFormControl = new FormControl(null,[]);

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
    private readonly _profileService: ProfileService
  ) { }


}
