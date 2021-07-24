import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TitleAndPropertyComponent } from './title-and-property.component';



@NgModule({
  declarations: [
    TitleAndPropertyComponent
  ],
  exports: [
    TitleAndPropertyComponent
  ],
  imports: [
    CommonModule
  ]
})
export class TitleAndPropertyModule { }
