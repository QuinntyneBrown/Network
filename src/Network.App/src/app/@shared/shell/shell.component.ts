import { DOCUMENT } from '@angular/common';
import { ChangeDetectorRef, Component, Inject, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { NavigationService } from '@core';
import { Observable, of } from 'rxjs';


@Component({
  selector: 'app-shell',
  templateUrl: './shell.component.html',
  styleUrls: ['./shell.component.scss']
})
export class ShellComponent {

  public readonly vm$: Observable<any> = of({});

  constructor(
    private readonly _activatedRoute: ActivatedRoute,
    private readonly _navigationService: NavigationService,
    @Inject(DOCUMENT) private readonly _document: Document,
    private readonly _changeDetectorRef: ChangeDetectorRef
  ) { }

  public handleTitleClick() {
    this._navigationService.redirectToPublicDefault();
  }
}
