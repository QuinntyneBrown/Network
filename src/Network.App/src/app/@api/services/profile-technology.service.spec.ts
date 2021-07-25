import { TestBed } from '@angular/core/testing';

import { ProfileTechnologyService } from './profile-technology.service';

describe('ProfileTechnologyService', () => {
  let service: ProfileTechnologyService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ProfileTechnologyService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
