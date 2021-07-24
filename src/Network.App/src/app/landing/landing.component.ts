import { DataSource } from '@angular/cdk/collections';
import { Component } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { Profile, ProfileService } from '@api';
import { map } from 'rxjs/operators';

@Component({
  selector: 'app-landing',
  templateUrl: './landing.component.html',
  styleUrls: ['./landing.component.scss']
})
export class LandingComponent {

  public readonly vm$ = this._profileService
  .get()
  .pipe(
    map(profiles => {
      return {
        dataSource: new MatTableDataSource(profiles),
        displayedColumns: ["firstname", "lastname", "edit"]
      };
    })
  );

  constructor(
    private readonly _profileService: ProfileService,
    private readonly _router: Router
  ) { }

  public handleEditClick(profile: Profile) {
    this._router.navigate(["profile",profile.profileId]);
  }

  public handleCreateClick() {
    this._router.navigate(["profile", "create"]);
  }
}
