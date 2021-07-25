import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Position } from '@api';
import { BehaviorSubject } from 'rxjs';
import { map } from 'rxjs/operators';

@Component({
  selector: 'app-position-modal',
  templateUrl: './position-modal.component.html',
  styleUrls: ['./position-modal.component.scss']
})
export class PositionModalComponent {

  private readonly _position$: BehaviorSubject<Position> = new BehaviorSubject(null);

  public vm$ = this._position$
  .pipe(
    map(position => {
      return {
        position,
        form: new FormGroup({
          organizationId: new FormControl(null, [])
        })
      }
    })
  )

  constructor(
    @Inject(MAT_DIALOG_DATA) position: Position
  ) {
    this._position$.next(position);
  }
}
