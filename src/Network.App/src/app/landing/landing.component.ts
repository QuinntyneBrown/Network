import { DataSource } from '@angular/cdk/collections';
import { Component, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { Profile, ProfileService } from '@api';
import { EntityDataSource } from '@shared';
import { BehaviorSubject, combineLatest, forkJoin, Observable, of, Subject } from 'rxjs';
import { map, switchMap } from 'rxjs/operators';

@Component({
  selector: 'app-landing',
  templateUrl: './landing.component.html',
  styleUrls: ['./landing.component.scss']
})
export class LandingComponent {

  private readonly _destroyed$ = new Subject();

  @ViewChild(MatPaginator) public paginator: MatPaginator;

  private readonly index$: BehaviorSubject<number> = new BehaviorSubject(0);
  private readonly pageSize$: BehaviorSubject<number> = new BehaviorSubject(5);
  private readonly _dataSource: EntityDataSource<Profile> = new EntityDataSource(this._profileService);

  public readonly vm$: Observable<{
    dataSource: EntityDataSource<Profile>,
    columnsToDisplay: string[],
    length$: Observable<number>,
    pageNumber: number,
    pageSize: number
  }> = combineLatest([this.index$, this.pageSize$])
  .pipe(
    switchMap(([index,pageSize]) => combineLatest([
      of(["firstname", "lastname", "edit"]),
      of(index),
      of(pageSize)
    ])
    .pipe(
      map(([columnsToDisplay, pageNumber, pageSize]) => {
        this._dataSource.getPage({ pageIndex: index, pageSize });
        return {
          dataSource: this._dataSource,
          columnsToDisplay,
          length$: this._dataSource.length$,
          pageSize,
          pageNumber
        }
      })
    ))
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
