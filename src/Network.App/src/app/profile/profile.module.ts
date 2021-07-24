import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ProfileRoutingModule } from './profile-routing.module';
import { ProfileComponent } from './profile.component';
import { BentoBoxModule } from '@shared';
import { DigitalAssetUploadModule } from '@shared/digital-asset-upload/digital-asset-upload.module';
import { ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    ProfileComponent
  ],
  imports: [
    CommonModule,
    ProfileRoutingModule,
    BentoBoxModule,
    DigitalAssetUploadModule,
    ReactiveFormsModule
  ]
})
export class ProfileModule { }
