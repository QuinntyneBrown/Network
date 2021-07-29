import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';

@Injectable()
export class ProfileContextService {

  private readonly _refresh$: Subject<void> = new Subject();

  public refresh$: Observable<void> = this._refresh$.asObservable();

  public refresh() {
    this._refresh$.next()
  }

}
