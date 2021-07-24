import { Location } from '@angular/common';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class NavigationService {
  constructor(
    private readonly _location: Location,
    private readonly _router: Router
    ) {}

  loginUrl = '/login';

  lastPath: string = '';

  defaultPath = '/workspace';

  setLoginUrl(value: string): void {
    this.loginUrl = value;
  }

  setDefaultUrl(value: string): void {
    this.defaultPath = value;
  }

  public redirectToLogin(): void {
    this._router.navigate([this.loginUrl]);
  }

  public redirectToPublicDefault(): void {
    this._router.navigate(['']);
  }

  public back():void {
    this._location.back();
  }

  public redirectPreLogin(): void {
    if (this.lastPath && this.lastPath !== this.loginUrl) {
      this._router.navigateByUrl(this.lastPath);
      this.lastPath = '';
    } else {
      this._router.navigate([this.defaultPath]);
    }
  }
}
