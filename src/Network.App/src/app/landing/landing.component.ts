import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { ProfileService } from '@api';
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
    map(profiles => ({ profiles: new MatTableDataSource(profiles) }))
  );

  public readonly displayedColumns = ["firstname", "lastname", "actions"];

  constructor(
    private readonly _profileService: ProfileService
  ) {

  }

}
