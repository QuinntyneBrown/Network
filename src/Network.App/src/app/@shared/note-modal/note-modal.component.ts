import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ProfileNoteService } from '@api';
import { BehaviorSubject } from 'rxjs';

@Component({
  selector: 'app-note-modal',
  templateUrl: './note-modal.component.html',
  styleUrls: ['./note-modal.component.scss']
})
export class NoteModalComponent  {

  private readonly _profileId$: BehaviorSubject<string> = new BehaviorSubject(null);

  constructor(
    private readonly _profileNoteService: ProfileNoteService,
    @Inject(MAT_DIALOG_DATA) private readonly _profileId: string
  ) {
    this._profileId$.next(_profileId);
  }

}
