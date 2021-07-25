import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ExperienceComponent } from './experience.component';
import { PositionModule } from '@shared/position';
import { MatButtonModule } from '@angular/material/button';
import { ExperienceModalModule } from '@shared/experience-modal';
import { MatDialogModule } from '@angular/material/dialog';
import { PositionModalModule } from '@shared/position-modal';
import { DatesEmployedModule } from '@shared/dates-employed';


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
    MatDialogModule,
    PositionModalModule,
    MatDialogModule,
    DatesEmployedModule
  ]
})
export class ExperienceModule { }
