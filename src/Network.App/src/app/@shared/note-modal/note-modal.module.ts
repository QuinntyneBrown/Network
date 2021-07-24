import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NoteModalComponent } from './note-modal.component';



@NgModule({
  declarations: [
    NoteModalComponent
  ],
  exports: [
    NoteModalComponent
  ],
  imports: [
    CommonModule
  ]
})
export class NoteModalModule { }
