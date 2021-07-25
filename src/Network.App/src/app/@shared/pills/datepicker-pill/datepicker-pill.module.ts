import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { DateAdapter, MAT_DATE_LOCALE, MAT_DATE_FORMATS, MatNativeDateModule } from "@angular/material/core";
import { MomentDateAdapter, MAT_MOMENT_DATE_FORMATS, MatMomentDateModule } from "@angular/material-moment-adapter";
import { DatepickerPillComponent } from './datepicker-pill.component';
import { MatMenuModule } from '@angular/material/menu';
import { MatDatepickerModule } from '@angular/material/datepicker';

@NgModule({
  declarations: [
    DatepickerPillComponent
  ],
  exports: [
    DatepickerPillComponent,
    MatMomentDateModule,
    MatNativeDateModule
  ],
  providers: [
    { provide: DateAdapter, useClass: MomentDateAdapter, deps: [MAT_DATE_LOCALE] },
    { provide: MAT_DATE_FORMATS, useValue: MAT_MOMENT_DATE_FORMATS }
  ],
  imports: [
    MatMenuModule,
    ReactiveFormsModule,
    FormsModule,
    CommonModule,
    MatMomentDateModule,
    MatNativeDateModule,
    MatDatepickerModule
  ]
})
export class DatepickerPillModule { }
