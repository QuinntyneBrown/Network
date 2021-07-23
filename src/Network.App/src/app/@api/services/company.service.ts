import { Injectable, Inject } from '@angular/core';
import { baseUrl } from '@core/constants';
import { HttpClient } from '@angular/common/http';
import { Company } from '@api';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { IPagableService } from '@core/ipagable-service';
import { EntityPage } from '@core/entity-page';

@Injectable({
  providedIn: 'root'
})
export class CompanyService implements IPagableService<Company> {

  uniqueIdentifierName: string = "companyId";

  constructor(
    @Inject(baseUrl) private readonly _baseUrl: string,
    private readonly _client: HttpClient
  ) { }

  getPage(options: { pageIndex: number; pageSize: number; }): Observable<EntityPage<Company>> {
    return this._client.get<EntityPage<Company>>(`${this._baseUrl}api/company/page/${options.pageSize}/${options.pageIndex}`)
  }

  public get(): Observable<Company[]> {
    return this._client.get<{ companies: Company[] }>(`${this._baseUrl}api/company`)
      .pipe(
        map(x => x.companies)
      );
  }

  public getById(options: { companyId: string }): Observable<Company> {
    return this._client.get<{ company: Company }>(`${this._baseUrl}api/company/${options.companyId}`)
      .pipe(
        map(x => x.company)
      );
  }

  public remove(options: { company: Company }): Observable<void> {
    return this._client.delete<void>(`${this._baseUrl}api/company/${options.company.companyId}`);
  }

  public create(options: { company: Company }): Observable<{ company: Company }> {
    return this._client.post<{ company: Company }>(`${this._baseUrl}api/company`, { company: options.company });
  }
  
  public update(options: { company: Company }): Observable<{ company: Company }> {
    return this._client.put<{ company: Company }>(`${this._baseUrl}api/company`, { company: options.company });
  }
}
