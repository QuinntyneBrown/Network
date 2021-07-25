import { Injectable, Inject } from '@angular/core';
import { baseUrl } from '@core/constants';
import { HttpClient } from '@angular/common/http';
import { OrganizationTechnology } from '@api';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { IPagableService } from '@core/ipagable-service';
import { EntityPage } from '@core/entity-page';

@Injectable({
  providedIn: 'root'
})
export class OrganizationTechnologyService implements IPagableService<OrganizationTechnology> {

  uniqueIdentifierName: string = "organizationTechnologyId";

  constructor(
    @Inject(baseUrl) private readonly _baseUrl: string,
    private readonly _client: HttpClient
  ) { }

  getPage(options: { pageIndex: number; pageSize: number; }): Observable<EntityPage<OrganizationTechnology>> {
    return this._client.get<EntityPage<OrganizationTechnology>>(`${this._baseUrl}api/organizationTechnology/page/${options.pageSize}/${options.pageIndex}`)
  }

  public get(): Observable<OrganizationTechnology[]> {
    return this._client.get<{ organizationTechnologies: OrganizationTechnology[] }>(`${this._baseUrl}api/organizationTechnology`)
      .pipe(
        map(x => x.organizationTechnologies)
      );
  }

  public getById(options: { organizationTechnologyId: string }): Observable<OrganizationTechnology> {
    return this._client.get<{ organizationTechnology: OrganizationTechnology }>(`${this._baseUrl}api/organizationTechnology/${options.organizationTechnologyId}`)
      .pipe(
        map(x => x.organizationTechnology)
      );
  }

  public remove(options: { organizationTechnology: OrganizationTechnology }): Observable<void> {
    return this._client.delete<void>(`${this._baseUrl}api/organizationTechnology/${options.organizationTechnology.organizationTechnologyId}`);
  }

  public create(options: { organizationTechnology: OrganizationTechnology }): Observable<{ organizationTechnology: OrganizationTechnology }> {
    return this._client.post<{ organizationTechnology: OrganizationTechnology }>(`${this._baseUrl}api/organizationTechnology`, { organizationTechnology: options.organizationTechnology });
  }
  
  public update(options: { organizationTechnology: OrganizationTechnology }): Observable<{ organizationTechnology: OrganizationTechnology }> {
    return this._client.put<{ organizationTechnology: OrganizationTechnology }>(`${this._baseUrl}api/organizationTechnology`, { organizationTechnology: options.organizationTechnology });
  }
}
