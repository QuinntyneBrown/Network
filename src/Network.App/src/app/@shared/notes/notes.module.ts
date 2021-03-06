import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NotesComponent } from './notes.component';
import { MatButtonModule } from '@angular/material/button';
import { NoteModalModule } from '@shared/note-modal';
import { MatDialogModule } from '@angular/material/dialog';



@NgModule({
  declarations: [
    NotesComponent
  ],
  exports: [
    NotesComponent
  ],
  imports: [
    CommonModule,
    MatButtonModule,
    NoteModalModule,
    MatDialogModule
  ]
})
export class NotesModule { }
