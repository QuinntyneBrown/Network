import { Injectable, Inject } from '@angular/core';
import { baseUrl } from '@core/constants';
import { HttpClient } from '@angular/common/http';
import { ProfileNote } from '@api';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { IPagableService } from '@core/ipagable-service';
import { EntityPage } from '@core/entity-page';

@Injectable({
  providedIn: 'root'
})
export class ProfileNoteService implements IPagableService<ProfileNote> {

  uniqueIdentifierName: string = "profileNoteId";

  constructor(
    @Inject(baseUrl) private readonly _baseUrl: string,
    private readonly _client: HttpClient
  ) { }

  getPage(options: { pageIndex: number; pageSize: number; }): Observable<EntityPage<ProfileNote>> {
    return this._client.get<EntityPage<ProfileNote>>(`${this._baseUrl}api/profileNote/page/${options.pageSize}/${options.pageIndex}`)
  }

  public get(): Observable<ProfileNote[]> {
    return this._client.get<{ profileNotes: ProfileNote[] }>(`${this._baseUrl}api/profileNote`)
      .pipe(
        map(x => x.profileNotes)
      );
  }

  public getById(options: { profileNoteId: string }): Observable<ProfileNote> {
    return this._client.get<{ profileNote: ProfileNote }>(`${this._baseUrl}api/profileNote/${options.profileNoteId}`)
      .pipe(
        map(x => x.profileNote)
      );
  }

  public remove(options: { profileNote: ProfileNote }): Observable<void> {
    return this._client.delete<void>(`${this._baseUrl}api/profileNote/${options.profileNote.profileNoteId}`);
  }

  public create(options: { profileNote: ProfileNote }): Observable<{ profileNote: ProfileNote }> {
    return this._client.post<{ profileNote: ProfileNote }>(`${this._baseUrl}api/profileNote`, { profileNote: options.profileNote });
  }
  
  public update(options: { profileNote: ProfileNote }): Observable<{ profileNote: ProfileNote }> {
    return this._client.put<{ profileNote: ProfileNote }>(`${this._baseUrl}api/profileNote`, { profileNote: options.profileNote });
  }
}
