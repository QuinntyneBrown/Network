import { Component, Inject } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ProfileService } from '@api';
import { BehaviorSubject, Subject } from 'rxjs';
import { map, tap } from 'rxjs/operators';

@Component({
  selector: 'app-experience-modal',
  templateUrl: './experience-modal.component.html',
  styleUrls: ['./experience-modal.component.scss']
})
export class ExperienceModalComponent {
  private _profileId$: BehaviorSubject<string> = new BehaviorSubject(null);

  public vm$ = this._profileId$
  .pipe(
    map(profileId => {
      return {
        form: new FormGroup({
          organizationId: new FormControl(null,[Validators.required]),
          profileId: new FormControl(profileId,[Validators.required]),
          title: new FormControl(null,[]),
          datesEmployed: new FormControl(null,[])
        })
      }
    })
  );



  constructor(
    private readonly _dialogRef: MatDialogRef<ExperienceModalComponent>,
    private readonly _profileService: ProfileService,
    @Inject(MAT_DIALOG_DATA) private readonly profileId: string
  ) {
    this._profileId$.next(profileId);
  }

  public handleSaveClick(vm) {
    this._profileService.createExperience({ profileId: this.profileId, position: vm.form.value })
    .pipe(
      tap(x => this._dialogRef.close())
    )
    .subscribe()
  }
}
