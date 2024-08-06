import { TestBed } from '@angular/core/testing';

import { DataCallsService } from './data-calls.service';

describe('DataCallsService', () => {
  let service: DataCallsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DataCallsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
