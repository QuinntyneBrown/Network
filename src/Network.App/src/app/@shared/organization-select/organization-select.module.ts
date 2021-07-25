import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { OrganizationSelectComponent } from './organization-select.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSelectModule } from '@angular/material/select';



@NgModule({
  declarations: [
    OrganizationSelectComponent
  ],
  exports: [
    OrganizationSelectComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatInputModule,
    MatFormFieldModule,
    MatSelectModule
  ]
})
export class OrganizationSelectModule { }
