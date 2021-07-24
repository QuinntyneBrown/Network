import { Component, Input, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Position } from '@api';
import { ExperienceModalComponent } from '@shared/experience-modal';

@Component({
  selector: 'app-experience',
  templateUrl: './experience.component.html',
  styleUrls: ['./experience.component.scss']
})
export class ExperienceComponent {

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
    .subscribe();
  }

}
