import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { OrganizationRoutingModule } from './organization-routing.module';
import { OrganizationComponent } from './organization.component';
import { BentoBoxModule } from '@shared';
import { DigitalAssetUploadModule } from '@shared/digital-asset-upload/digital-asset-upload.module';
import { ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';


@NgModule({
  declarations: [
    OrganizationComponent
  ],
  imports: [
    CommonModule,
    OrganizationRoutingModule,
    BentoBoxModule,
    DigitalAssetUploadModule,
    ReactiveFormsModule,
    MatButtonModule,
    MatFormFieldModule,
    MatInputModule,
  ]
})
export class OrganizationModule { }
