import { Injectable, Inject } from '@angular/core';
import { baseUrl } from '@core/constants';
import { HttpClient } from '@angular/common/http';
import { TeamTechnology } from '@api';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { IPagableService } from '@core/ipagable-service';
import { EntityPage } from '@core/entity-page';

@Injectable({
  providedIn: 'root'
})
export class TeamTechnologyService implements IPagableService<TeamTechnology> {

  uniqueIdentifierName: string = "teamTechnologyId";

  constructor(
    @Inject(baseUrl) private readonly _baseUrl: string,
    private readonly _client: HttpClient
  ) { }

  getPage(options: { pageIndex: number; pageSize: number; }): Observable<EntityPage<TeamTechnology>> {
    return this._client.get<EntityPage<TeamTechnology>>(`${this._baseUrl}api/teamTechnology/page/${options.pageSize}/${options.pageIndex}`)
  }

  public get(): Observable<TeamTechnology[]> {
    return this._client.get<{ teamTechnologies: TeamTechnology[] }>(`${this._baseUrl}api/teamTechnology`)
      .pipe(
        map(x => x.teamTechnologies)
      );
  }

  public getById(options: { teamTechnologyId: string }): Observable<TeamTechnology> {
    return this._client.get<{ teamTechnology: TeamTechnology }>(`${this._baseUrl}api/teamTechnology/${options.teamTechnologyId}`)
      .pipe(
        map(x => x.teamTechnology)
      );
  }

  public remove(options: { teamTechnology: TeamTechnology }): Observable<void> {
    return this._client.delete<void>(`${this._baseUrl}api/teamTechnology/${options.teamTechnology.teamTechnologyId}`);
  }

  public create(options: { teamTechnology: TeamTechnology }): Observable<{ teamTechnology: TeamTechnology }> {
    return this._client.post<{ teamTechnology: TeamTechnology }>(`${this._baseUrl}api/teamTechnology`, { teamTechnology: options.teamTechnology });
  }
  
  public update(options: { teamTechnology: TeamTechnology }): Observable<{ teamTechnology: TeamTechnology }> {
    return this._client.put<{ teamTechnology: TeamTechnology }>(`${this._baseUrl}api/teamTechnology`, { teamTechnology: options.teamTechnology });
  }
}
