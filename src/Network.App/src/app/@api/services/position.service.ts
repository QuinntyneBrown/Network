import { Injectable, Inject } from '@angular/core';
import { baseUrl } from '@core/constants';
import { HttpClient } from '@angular/common/http';
import { Position } from '@api';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { IPagableService } from '@core/ipagable-service';
import { EntityPage } from '@core/entity-page';

@Injectable({
  providedIn: 'root'
})
export class PositionService implements IPagableService<Position> {

  uniqueIdentifierName: string = "positionId";

  constructor(
    @Inject(baseUrl) private readonly _baseUrl: string,
    private readonly _client: HttpClient
  ) { }

  getPage(options: { pageIndex: number; pageSize: number; }): Observable<EntityPage<Position>> {
    return this._client.get<EntityPage<Position>>(`${this._baseUrl}api/position/page/${options.pageSize}/${options.pageIndex}`)
  }

  public get(): Observable<Position[]> {
    return this._client.get<{ positions: Position[] }>(`${this._baseUrl}api/position`)
      .pipe(
        map(x => x.positions)
      );
  }

  public getById(options: { positionId: string }): Observable<Position> {
    return this._client.get<{ position: Position }>(`${this._baseUrl}api/position/${options.positionId}`)
      .pipe(
        map(x => x.position)
      );
  }

  public remove(options: { position: Position }): Observable<void> {
    return this._client.delete<void>(`${this._baseUrl}api/position/${options.position.positionId}`);
  }

  public create(options: { position: Position }): Observable<{ position: Position }> {
    return this._client.post<{ position: Position }>(`${this._baseUrl}api/position`, { position: options.position });
  }
  
  public update(options: { position: Position }): Observable<{ position: Position }> {
    return this._client.put<{ position: Position }>(`${this._baseUrl}api/position`, { position: options.position });
  }
}
