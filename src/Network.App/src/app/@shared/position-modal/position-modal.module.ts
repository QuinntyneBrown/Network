import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PositionModalComponent } from './position-modal.component';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatDialogModule } from '@angular/material/dialog';
import { OrganizationSelectModule } from '@shared/organization-select';
import { ReactiveFormsModule } from '@angular/forms';
import { DatesEmployedModule } from '@shared/dates-employed';



@NgModule({
  declarations: [
    PositionModalComponent
  ],
  exports: [
    PositionModalComponent
  ],
  imports: [
    CommonModule,
    MatButtonModule,
    MatIconModule,
    MatDialogModule,
    OrganizationSelectModule,
    ReactiveFormsModule,
    DatesEmployedModule
  ]
})
export class PositionModalModule { }
