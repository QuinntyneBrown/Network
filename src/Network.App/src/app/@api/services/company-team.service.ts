import { Injectable, Inject } from '@angular/core';
import { baseUrl } from '@core/constants';
import { HttpClient } from '@angular/common/http';
import { CompanyTeam } from '@api';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { IPagableService } from '@core/ipagable-service';
import { EntityPage } from '@core/entity-page';

@Injectable({
  providedIn: 'root'
})
export class CompanyTeamService implements IPagableService<CompanyTeam> {

  uniqueIdentifierName: string = "companyTeamId";

  constructor(
    @Inject(baseUrl) private readonly _baseUrl: string,
    private readonly _client: HttpClient
  ) { }

  getPage(options: { pageIndex: number; pageSize: number; }): Observable<EntityPage<CompanyTeam>> {
    return this._client.get<EntityPage<CompanyTeam>>(`${this._baseUrl}api/companyTeam/page/${options.pageSize}/${options.pageIndex}`)
  }

  public get(): Observable<CompanyTeam[]> {
    return this._client.get<{ companyTeams: CompanyTeam[] }>(`${this._baseUrl}api/companyTeam`)
      .pipe(
        map(x => x.companyTeams)
      );
  }

  public getById(options: { companyTeamId: string }): Observable<CompanyTeam> {
    return this._client.get<{ companyTeam: CompanyTeam }>(`${this._baseUrl}api/companyTeam/${options.companyTeamId}`)
      .pipe(
        map(x => x.companyTeam)
      );
  }

  public remove(options: { companyTeam: CompanyTeam }): Observable<void> {
    return this._client.delete<void>(`${this._baseUrl}api/companyTeam/${options.companyTeam.companyTeamId}`);
  }

  public create(options: { companyTeam: CompanyTeam }): Observable<{ companyTeam: CompanyTeam }> {
    return this._client.post<{ companyTeam: CompanyTeam }>(`${this._baseUrl}api/companyTeam`, { companyTeam: options.companyTeam });
  }
  
  public update(options: { companyTeam: CompanyTeam }): Observable<{ companyTeam: CompanyTeam }> {
    return this._client.put<{ companyTeam: CompanyTeam }>(`${this._baseUrl}api/companyTeam`, { companyTeam: options.companyTeam });
  }
}
