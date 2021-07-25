import { Component, Inject, OnDestroy, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { OrganizationService } from '@api';
import { baseUrl } from '@core';
import { Observable, Subject } from 'rxjs';
import { map, takeUntil } from 'rxjs/operators';

@Component({
  selector: 'app-organization',
  templateUrl: './organization.component.html',
  styleUrls: ['./organization.component.scss']
})
export class OrganizationComponent implements OnDestroy   {

  private readonly _destroyed$ = new Subject();

  public readonly vm$ = this._organizationService.get()
  .pipe(
    map(organizations => {
      return {
        organizations,
        form: new FormGroup({
          name: new FormControl(null,[]),
          logoDigitalAssetId: new FormControl(null,[])
        })
      }
    })
  );

  public get baseUrl() {
    return this._baseUrl;
  }

  constructor(
    private readonly _organizationService: OrganizationService,
    @Inject(baseUrl) private readonly _baseUrl: string
  ) { }

    public handleSaveClick(vm) {
      this._organizationService
      .create({ organization: vm.form.value })
      .pipe(
        takeUntil(this._destroyed$)
      ).subscribe();
    }

    ngOnDestroy() {
      this._destroyed$.next();
      this._destroyed$.complete();
    }
}
