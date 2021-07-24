import { Component, EventEmitter, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent {
  @Output() public titleClick: EventEmitter<void> = new EventEmitter();
  @Output() public menuClick: EventEmitter<void> = new EventEmitter();
}
