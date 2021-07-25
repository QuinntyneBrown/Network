import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ExperienceModalComponent } from './experience-modal.component';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatDialogModule } from '@angular/material/dialog';
import { ReactiveFormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { CompanySelectModule } from '@shared/company-select';
import { OrganizationSelectModule } from '@shared/organization-select';
import { DatesEmployedModule } from '@shared/dates-employed';



@NgModule({
  declarations: [
    ExperienceModalComponent
  ],
  exports: [
    ExperienceModalComponent
  ],
  imports: [
    CommonModule,
    MatButtonModule,
    MatIconModule,
    MatDialogModule,
    ReactiveFormsModule,
    MatInputModule,
    MatFormFieldModule,
    CompanySelectModule,
    OrganizationSelectModule,
    DatesEmployedModule

  ]
})
export class ExperienceModalModule { }
