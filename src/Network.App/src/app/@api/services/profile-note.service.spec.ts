import { TestBed } from '@angular/core/testing';

import { ProfileNoteService } from './profile-note.service';

describe('ProfileNoteService', () => {
  let service: ProfileNoteService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ProfileNoteService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
