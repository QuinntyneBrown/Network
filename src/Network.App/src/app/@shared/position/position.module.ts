import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PositionComponent } from './position.component';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { LogoModule } from '@shared/logo';



@NgModule({
  declarations: [
    PositionComponent
  ],
  exports: [
    PositionComponent
  ],
  imports: [
    CommonModule,
    MatIconModule,
    MatButtonModule,
    LogoModule
  ]
})
export class PositionModule { }
