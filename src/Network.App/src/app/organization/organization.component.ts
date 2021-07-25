import { Component, OnDestroy } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Organization, OrganizationService } from '@api';
import { of, Subject } from 'rxjs';
import { map, switchMap, takeUntil } from 'rxjs/operators';

export enum OrganizationState {
  Edit,
  Create,
  View
}

@Component({
  selector: 'app-organization',
  templateUrl: './organization.component.html',
  styleUrls: ['./organization.component.scss']
})
export class OrganizationComponent implements OnDestroy   {

  private readonly _destroyed$ = new Subject();

  public readonly OrganizationState: typeof OrganizationState = OrganizationState;

  private get _initialVm$() {
    return this._activatedRoute
    .paramMap
    .pipe(
      map(paramMap => {
        return {
          state: paramMap.get("editId") ? OrganizationState.Edit: OrganizationState.Create,
          organiztionId: paramMap.get("editId"),
          organization: null
        }
      })
    )
  }

  public readonly vm$ = this._initialVm$
  .pipe(
    switchMap(vm => this._organizationService.get().pipe(
      map(organizations => (Object.assign(vm, {organizations })))
    )),
    switchMap(vm => {

      if(vm.organiztionId) {
        return this._organizationService.getById({ organizationId: vm.organiztionId })
        .pipe(
          map(organization => Object.assign(vm, { organization }))
        )
      }
      return of(vm)
    }),
    map(vm => {
      return Object.assign(vm, {
        form: new FormGroup({
          organizationId: new FormControl(vm.organization?.organizationId, []),
          name: new FormControl(vm.organization?.name,[]),
          logoDigitalAssetId: new FormControl(vm.organization?.logoDigitalAssetId,[])
        })
      })
    })
  );

  constructor(
    private readonly _activatedRoute: ActivatedRoute,
    private readonly _organizationService: OrganizationService,
    private readonly _router: Router
  ) { }

    public handleSaveClick(vm) {
      const obs$ = vm.state == OrganizationState.Create
      ? this._organizationService
      .create({ organization: vm.form.value })
      : this._organizationService
      .update({ organization: vm.form.value });

      obs$.pipe(
        takeUntil(this._destroyed$)
      ).subscribe();
    }

    public handleEditClick(organization: Organization) {
      this._router.navigate(['/','organization','edit',organization.organizationId])
    }

    ngOnDestroy() {
      this._destroyed$.next();
      this._destroyed$.complete();
    }
}
