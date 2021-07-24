import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { OrganizationSelectComponent } from './organization-select.component';



@NgModule({
  declarations: [
    OrganizationSelectComponent
  ],
  exports: [
    OrganizationSelectComponent
  ],
  imports: [
    CommonModule
  ]
})
export class OrganizationSelectModule { }
