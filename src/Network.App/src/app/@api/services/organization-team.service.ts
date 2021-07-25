import { Injectable, Inject } from '@angular/core';
import { baseUrl } from '@core/constants';
import { HttpClient } from '@angular/common/http';
import { OrganizationTeam } from '@api';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { IPagableService } from '@core/ipagable-service';
import { EntityPage } from '@core/entity-page';

@Injectable({
  providedIn: 'root'
})
export class OrganizationTeamService implements IPagableService<OrganizationTeam> {

  uniqueIdentifierName: string = "organizationTeamId";

  constructor(
    @Inject(baseUrl) private readonly _baseUrl: string,
    private readonly _client: HttpClient
  ) { }

  getPage(options: { pageIndex: number; pageSize: number; }): Observable<EntityPage<OrganizationTeam>> {
    return this._client.get<EntityPage<OrganizationTeam>>(`${this._baseUrl}api/organizationTeam/page/${options.pageSize}/${options.pageIndex}`)
  }

  public get(): Observable<OrganizationTeam[]> {
    return this._client.get<{ organizationTeams: OrganizationTeam[] }>(`${this._baseUrl}api/organizationTeam`)
      .pipe(
        map(x => x.organizationTeams)
      );
  }

  public getById(options: { organizationTeamId: string }): Observable<OrganizationTeam> {
    return this._client.get<{ organizationTeam: OrganizationTeam }>(`${this._baseUrl}api/organizationTeam/${options.organizationTeamId}`)
      .pipe(
        map(x => x.organizationTeam)
      );
  }

  public remove(options: { organizationTeam: OrganizationTeam }): Observable<void> {
    return this._client.delete<void>(`${this._baseUrl}api/organizationTeam/${options.organizationTeam.organizationTeamId}`);
  }

  public create(options: { organizationTeam: OrganizationTeam }): Observable<{ organizationTeam: OrganizationTeam }> {
    return this._client.post<{ organizationTeam: OrganizationTeam }>(`${this._baseUrl}api/organizationTeam`, { organizationTeam: options.organizationTeam });
  }
  
  public update(options: { organizationTeam: OrganizationTeam }): Observable<{ organizationTeam: OrganizationTeam }> {
    return this._client.put<{ organizationTeam: OrganizationTeam }>(`${this._baseUrl}api/organizationTeam`, { organizationTeam: options.organizationTeam });
  }
}
