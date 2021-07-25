import { Component, Input, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Position } from '@api';
import { ExperienceModalComponent } from '@shared/experience-modal';
import { PositionModalComponent } from '@shared/position-modal';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';

@Component({
  selector: 'app-experience',
  templateUrl: './experience.component.html',
  styleUrls: ['./experience.component.scss']
})
export class ExperienceComponent {
  private readonly _destroyed$: Subject<void> = new Subject();
  @Input() public readonly positions: Position[] = [];
  @Input() public readonly profileId!: string;

  constructor(
    private readonly _dialog: MatDialog
  ) { }

  public handleCreateClick() {
    this._dialog.open<ExperienceModalComponent>(ExperienceModalComponent, {
      panelClass:'g-modal-panel',
      data: this.profileId
    })
    .afterClosed()
    .pipe(
      takeUntil(this._destroyed$)
    )
    .subscribe();
  }

  public handleEditClick(data: Position) {
    this._dialog.open<PositionModalComponent>(PositionModalComponent, {
      panelClass:'g-modal-panel',
      data
    })
    .afterClosed()
    .pipe(
      takeUntil(this._destroyed$)
    )
    .subscribe();
  }
}
