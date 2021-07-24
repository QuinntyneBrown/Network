import { Component, Input, OnInit } from '@angular/core';
import { Note } from '@api';

@Component({
  selector: 'app-notes',
  templateUrl: './notes.component.html',
  styleUrls: ['./notes.component.scss']
})
export class NotesComponent implements OnInit {

  @Input() public notes: Note[] = [];

  constructor() { }

  ngOnInit(): void {
  }

}
