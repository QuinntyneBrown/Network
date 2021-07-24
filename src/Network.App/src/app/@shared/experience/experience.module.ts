import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ExperienceComponent } from './experience.component';
import { PositionModule } from '@shared/position';
import { MatButtonModule } from '@angular/material/button';
import { ExperienceModalModule } from '@shared/experience-modal';
import { MatDialogModule } from '@angular/material/dialog';


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
    MatButtonModule,
    ExperienceModalModule,
    MatDialogModule
  ]
})
export class ExperienceModule { }
