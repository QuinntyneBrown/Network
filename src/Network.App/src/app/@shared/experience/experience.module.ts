import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ExperienceComponent } from './experience.component';
import { PositionModule } from '@shared/position';
import { MatButtonModule } from '@angular/material/button';



@NgModule({
  declarations: [
    ExperienceComponent
  ],
  exports: [
    ExperienceComponent
  ],
  imports: [
    CommonModule,
    PositionModule,
    MatButtonModule
  ]
})
export class ExperienceModule { }
