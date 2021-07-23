import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ProfileService } from '@api';
import { map, switchMap } from 'rxjs/operators';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss']
})
export class ProfileComponent  {

  public readonly vm$ = this._activatedRoute.paramMap
  .pipe(
    switchMap(paramMap => this._profileService.getById({ profileId: paramMap.get("id") })),
    map( profile => ({ profile }))
  );

  constructor(
    private readonly _activatedRoute: ActivatedRoute,
    private readonly _profileService: ProfileService
  ) { }



}
