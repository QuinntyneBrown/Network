import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CompanySelectComponent } from './company-select.component';



@NgModule({
  declarations: [
    CompanySelectComponent
  ],
  exports: [
    CompanySelectComponent
  ],
  imports: [
    CommonModule
  ]
})
export class CompanySelectModule { }
