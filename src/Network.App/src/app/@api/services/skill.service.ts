import { Injectable, Inject } from '@angular/core';
import { baseUrl } from '@core/constants';
import { HttpClient } from '@angular/common/http';
import { Skill } from '@api';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { IPagableService } from '@core/ipagable-service';
import { EntityPage } from '@core/entity-page';

@Injectable({
  providedIn: 'root'
})
export class SkillService implements IPagableService<Skill> {

  uniqueIdentifierName: string = "skillId";

  constructor(
    @Inject(baseUrl) private readonly _baseUrl: string,
    private readonly _client: HttpClient
  ) { }

  getPage(options: { pageIndex: number; pageSize: number; }): Observable<EntityPage<Skill>> {
    return this._client.get<EntityPage<Skill>>(`${this._baseUrl}api/skill/page/${options.pageSize}/${options.pageIndex}`)
  }

  public get(): Observable<Skill[]> {
    return this._client.get<{ skills: Skill[] }>(`${this._baseUrl}api/skill`)
      .pipe(
        map(x => x.skills)
      );
  }

  public getById(options: { skillId: string }): Observable<Skill> {
    return this._client.get<{ skill: Skill }>(`${this._baseUrl}api/skill/${options.skillId}`)
      .pipe(
        map(x => x.skill)
      );
  }

  public remove(options: { skill: Skill }): Observable<void> {
    return this._client.delete<void>(`${this._baseUrl}api/skill/${options.skill.skillId}`);
  }

  public create(options: { skill: Skill }): Observable<{ skill: Skill }> {
    return this._client.post<{ skill: Skill }>(`${this._baseUrl}api/skill`, { skill: options.skill });
  }
  
  public update(options: { skill: Skill }): Observable<{ skill: Skill }> {
    return this._client.put<{ skill: Skill }>(`${this._baseUrl}api/skill`, { skill: options.skill });
  }
}
