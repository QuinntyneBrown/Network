import { Injectable, Inject } from '@angular/core';
import { baseUrl } from '@core/constants';
import { HttpClient } from '@angular/common/http';
import { Location } from '@api';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { IPagableService } from '@core/ipagable-service';
import { EntityPage } from '@core/entity-page';

@Injectable({
  providedIn: 'root'
})
export class LocationService implements IPagableService<Location> {

  uniqueIdentifierName: string = "locationId";

  constructor(
    @Inject(baseUrl) private readonly _baseUrl: string,
    private readonly _client: HttpClient
  ) { }

  getPage(options: { pageIndex: number; pageSize: number; }): Observable<EntityPage<Location>> {
    return this._client.get<EntityPage<Location>>(`${this._baseUrl}api/location/page/${options.pageSize}/${options.pageIndex}`)
  }

  public get(): Observable<Location[]> {
    return this._client.get<{ locations: Location[] }>(`${this._baseUrl}api/location`)
      .pipe(
        map(x => x.locations)
      );
  }

  public getById(options: { locationId: string }): Observable<Location> {
    return this._client.get<{ location: Location }>(`${this._baseUrl}api/location/${options.locationId}`)
      .pipe(
        map(x => x.location)
      );
  }

  public remove(options: { location: Location }): Observable<void> {
    return this._client.delete<void>(`${this._baseUrl}api/location/${options.location.locationId}`);
  }

  public create(options: { location: Location }): Observable<{ location: Location }> {
    return this._client.post<{ location: Location }>(`${this._baseUrl}api/location`, { location: options.location });
  }
  
  public update(options: { location: Location }): Observable<{ location: Location }> {
    return this._client.put<{ location: Location }>(`${this._baseUrl}api/location`, { location: options.location });
  }
}
