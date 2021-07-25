import { TestBed } from '@angular/core/testing';

import { CompanyTeamService } from './company-team.service';

describe('CompanyTeamService', () => {
  let service: CompanyTeamService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CompanyTeamService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
