import { Injectable, Inject } from '@angular/core';
import { baseUrl } from '@core/constants';
import { HttpClient } from '@angular/common/http';
import { Organization } from '@api';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { IPagableService } from '@core/ipagable-service';
import { EntityPage } from '@core/entity-page';

@Injectable({
  providedIn: 'root'
})
export class OrganizationService implements IPagableService<Organization> {

  uniqueIdentifierName: string = "organizationId";

  constructor(
    @Inject(baseUrl) private readonly _baseUrl: string,
    private readonly _client: HttpClient
  ) { }

  getPage(options: { pageIndex: number; pageSize: number; }): Observable<EntityPage<Organization>> {
    return this._client.get<EntityPage<Organization>>(`${this._baseUrl}api/organization/page/${options.pageSize}/${options.pageIndex}`)
  }

  public get(): Observable<Organization[]> {
    return this._client.get<{ organizations: Organization[] }>(`${this._baseUrl}api/organization`)
      .pipe(
        map(x => x.organizations)
      );
  }

  public getById(options: { organizationId: string }): Observable<Organization> {
    return this._client.get<{ organization: Organization }>(`${this._baseUrl}api/organization/${options.organizationId}`)
      .pipe(
        map(x => x.organization)
      );
  }

  public remove(options: { organization: Organization }): Observable<void> {
    return this._client.delete<void>(`${this._baseUrl}api/organization/${options.organization.organizationId}`);
  }

  public create(options: { organization: Organization }): Observable<{ organization: Organization }> {
    return this._client.post<{ organization: Organization }>(`${this._baseUrl}api/organization`, { organization: options.organization });
  }
  
  public update(options: { organization: Organization }): Observable<{ organization: Organization }> {
    return this._client.put<{ organization: Organization }>(`${this._baseUrl}api/organization`, { organization: options.organization });
  }
}
