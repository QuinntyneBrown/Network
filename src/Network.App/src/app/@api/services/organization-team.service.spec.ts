import { TestBed } from '@angular/core/testing';

import { OrganizationTeamService } from './organization-team.service';

describe('OrganizationTeamService', () => {
  let service: OrganizationTeamService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(OrganizationTeamService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
