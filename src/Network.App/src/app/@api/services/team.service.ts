import { Injectable, Inject } from '@angular/core';
import { baseUrl } from '@core/constants';
import { HttpClient } from '@angular/common/http';
import { Team } from '@api';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { IPagableService } from '@core/ipagable-service';
import { EntityPage } from '@core/entity-page';

@Injectable({
  providedIn: 'root'
})
export class TeamService implements IPagableService<Team> {

  uniqueIdentifierName: string = "teamId";

  constructor(
    @Inject(baseUrl) private readonly _baseUrl: string,
    private readonly _client: HttpClient
  ) { }

  getPage(options: { pageIndex: number; pageSize: number; }): Observable<EntityPage<Team>> {
    return this._client.get<EntityPage<Team>>(`${this._baseUrl}api/team/page/${options.pageSize}/${options.pageIndex}`)
  }

  public get(): Observable<Team[]> {
    return this._client.get<{ teams: Team[] }>(`${this._baseUrl}api/team`)
      .pipe(
        map(x => x.teams)
      );
  }

  public getById(options: { teamId: string }): Observable<Team> {
    return this._client.get<{ team: Team }>(`${this._baseUrl}api/team/${options.teamId}`)
      .pipe(
        map(x => x.team)
      );
  }

  public remove(options: { team: Team }): Observable<void> {
    return this._client.delete<void>(`${this._baseUrl}api/team/${options.team.teamId}`);
  }

  public create(options: { team: Team }): Observable<{ team: Team }> {
    return this._client.post<{ team: Team }>(`${this._baseUrl}api/team`, { team: options.team });
  }
  
  public update(options: { team: Team }): Observable<{ team: Team }> {
    return this._client.put<{ team: Team }>(`${this._baseUrl}api/team`, { team: options.team });
  }
}
