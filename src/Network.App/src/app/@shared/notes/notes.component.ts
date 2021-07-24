import { Component, Input, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Note } from '@api';
import { NoteModalComponent } from '@shared/note-modal';

@Component({
  selector: 'app-notes',
  templateUrl: './notes.component.html',
  styleUrls: ['./notes.component.scss']
})
export class NotesComponent  {

  @Input() public notes: Note[] = [];

  @Input() public readonly profileId!: string;

  constructor(
    private readonly _dialog: MatDialog
  ) { }

  public handleCreateClick() {
    this._dialog.open<NoteModalComponent>(NoteModalComponent, {
      panelClass:'g-modal-panel',
      data: this.profileId
    })
    .afterClosed()
    .subscribe();
  }
}
