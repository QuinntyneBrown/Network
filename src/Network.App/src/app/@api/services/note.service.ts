import { Injectable, Inject } from '@angular/core';
import { baseUrl } from '@core/constants';
import { HttpClient } from '@angular/common/http';
import { Note } from '@api';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { IPagableService } from '@core/ipagable-service';
import { EntityPage } from '@core/entity-page';

@Injectable({
  providedIn: 'root'
})
export class NoteService implements IPagableService<Note> {

  uniqueIdentifierName: string = "noteId";

  constructor(
    @Inject(baseUrl) private readonly _baseUrl: string,
    private readonly _client: HttpClient
  ) { }

  getPage(options: { pageIndex: number; pageSize: number; }): Observable<EntityPage<Note>> {
    return this._client.get<EntityPage<Note>>(`${this._baseUrl}api/note/page/${options.pageSize}/${options.pageIndex}`)
  }

  public get(): Observable<Note[]> {
    return this._client.get<{ notes: Note[] }>(`${this._baseUrl}api/note`)
      .pipe(
        map(x => x.notes)
      );
  }

  public getById(options: { noteId: string }): Observable<Note> {
    return this._client.get<{ note: Note }>(`${this._baseUrl}api/note/${options.noteId}`)
      .pipe(
        map(x => x.note)
      );
  }

  public remove(options: { note: Note }): Observable<void> {
    return this._client.delete<void>(`${this._baseUrl}api/note/${options.note.noteId}`);
  }

  public create(options: { note: Note }): Observable<{ note: Note }> {
    return this._client.post<{ note: Note }>(`${this._baseUrl}api/note`, { note: options.note });
  }
  
  public update(options: { note: Note }): Observable<{ note: Note }> {
    return this._client.put<{ note: Note }>(`${this._baseUrl}api/note`, { note: options.note });
  }
}
