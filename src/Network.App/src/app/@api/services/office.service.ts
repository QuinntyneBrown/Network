import { Injectable, Inject } from '@angular/core';
import { baseUrl } from '@core/constants';
import { HttpClient } from '@angular/common/http';
import { Office } from '@api';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { IPagableService } from '@core/ipagable-service';
import { EntityPage } from '@core/entity-page';

@Injectable({
  providedIn: 'root'
})
export class OfficeService implements IPagableService<Office> {

  uniqueIdentifierName: string = "officeId";

  constructor(
    @Inject(baseUrl) private readonly _baseUrl: string,
    private readonly _client: HttpClient
  ) { }

  getPage(options: { pageIndex: number; pageSize: number; }): Observable<EntityPage<Office>> {
    return this._client.get<EntityPage<Office>>(`${this._baseUrl}api/office/page/${options.pageSize}/${options.pageIndex}`)
  }

  public get(): Observable<Office[]> {
    return this._client.get<{ offices: Office[] }>(`${this._baseUrl}api/office`)
      .pipe(
        map(x => x.offices)
      );
  }

  public getById(options: { officeId: string }): Observable<Office> {
    return this._client.get<{ office: Office }>(`${this._baseUrl}api/office/${options.officeId}`)
      .pipe(
        map(x => x.office)
      );
  }

  public remove(options: { office: Office }): Observable<void> {
    return this._client.delete<void>(`${this._baseUrl}api/office/${options.office.officeId}`);
  }

  public create(options: { office: Office }): Observable<{ office: Office }> {
    return this._client.post<{ office: Office }>(`${this._baseUrl}api/office`, { office: options.office });
  }
  
  public update(options: { office: Office }): Observable<{ office: Office }> {
    return this._client.put<{ office: Office }>(`${this._baseUrl}api/office`, { office: options.office });
  }
}
