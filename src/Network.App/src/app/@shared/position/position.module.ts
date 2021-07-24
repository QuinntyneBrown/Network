import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PositionComponent } from './position.component';



@NgModule({
  declarations: [
    PositionComponent
  ],
  exports: [
    PositionComponent
  ],
  imports: [
    CommonModule
  ]
})
export class PositionModule { }
