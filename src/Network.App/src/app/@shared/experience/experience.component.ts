import { Component, Input, OnInit } from '@angular/core';
import { Position } from '@api';

@Component({
  selector: 'app-experience',
  templateUrl: './experience.component.html',
  styleUrls: ['./experience.component.scss']
})
export class ExperienceComponent implements OnInit {

  @Input() public readonly positions: Position[] = [];

  constructor() { }

  ngOnInit(): void {
  }

}
