import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Position } from '@api';

@Component({
  selector: 'app-position',
  templateUrl: './position.component.html',
  styleUrls: ['./position.component.scss']
})
export class PositionComponent {

  @Output() public editClick: EventEmitter<Position> = new EventEmitter();

  @Input() public position!: Position;

}
