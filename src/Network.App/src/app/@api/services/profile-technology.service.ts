import { Injectable, Inject } from '@angular/core';
import { baseUrl } from '@core/constants';
import { HttpClient } from '@angular/common/http';
import { ProfileTechnology } from '@api';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { IPagableService } from '@core/ipagable-service';
import { EntityPage } from '@core/entity-page';

@Injectable({
  providedIn: 'root'
})
export class ProfileTechnologyService implements IPagableService<ProfileTechnology> {

  uniqueIdentifierName: string = "profileTechnologyId";

  constructor(
    @Inject(baseUrl) private readonly _baseUrl: string,
    private readonly _client: HttpClient
  ) { }

  getPage(options: { pageIndex: number; pageSize: number; }): Observable<EntityPage<ProfileTechnology>> {
    return this._client.get<EntityPage<ProfileTechnology>>(`${this._baseUrl}api/profileTechnology/page/${options.pageSize}/${options.pageIndex}`)
  }

  public get(): Observable<ProfileTechnology[]> {
    return this._client.get<{ profileTechnologies: ProfileTechnology[] }>(`${this._baseUrl}api/profileTechnology`)
      .pipe(
        map(x => x.profileTechnologies)
      );
  }

  public getById(options: { profileTechnologyId: string }): Observable<ProfileTechnology> {
    return this._client.get<{ profileTechnology: ProfileTechnology }>(`${this._baseUrl}api/profileTechnology/${options.profileTechnologyId}`)
      .pipe(
        map(x => x.profileTechnology)
      );
  }

  public remove(options: { profileTechnology: ProfileTechnology }): Observable<void> {
    return this._client.delete<void>(`${this._baseUrl}api/profileTechnology/${options.profileTechnology.profileTechnologyId}`);
  }

  public create(options: { profileTechnology: ProfileTechnology }): Observable<{ profileTechnology: ProfileTechnology }> {
    return this._client.post<{ profileTechnology: ProfileTechnology }>(`${this._baseUrl}api/profileTechnology`, { profileTechnology: options.profileTechnology });
  }
  
  public update(options: { profileTechnology: ProfileTechnology }): Observable<{ profileTechnology: ProfileTechnology }> {
    return this._client.put<{ profileTechnology: ProfileTechnology }>(`${this._baseUrl}api/profileTechnology`, { profileTechnology: options.profileTechnology });
  }
}
