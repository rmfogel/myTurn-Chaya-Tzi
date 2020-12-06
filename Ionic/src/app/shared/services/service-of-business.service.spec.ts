import { TestBed } from '@angular/core/testing';

import { ServiceOfBusinessService } from './service-of-business.service';

describe('ServiceOfBusinessService', () => {
  let service: ServiceOfBusinessService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ServiceOfBusinessService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
