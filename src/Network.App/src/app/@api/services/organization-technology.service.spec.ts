import { TestBed } from '@angular/core/testing';

import { OrganizationTechnologyService } from './organization-technology.service';

describe('OrganizationTechnologyService', () => {
  let service: OrganizationTechnologyService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(OrganizationTechnologyService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
