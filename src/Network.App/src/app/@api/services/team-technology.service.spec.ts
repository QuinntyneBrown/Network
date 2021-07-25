import { TestBed } from '@angular/core/testing';

import { TeamTechnologyService } from './team-technology.service';

describe('TeamTechnologyService', () => {
  let service: TeamTechnologyService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TeamTechnologyService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
