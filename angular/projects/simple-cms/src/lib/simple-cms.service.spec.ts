import { TestBed } from '@angular/core/testing';
import { SimpleCMSService } from './services/simple-cms.service';
import { RestService } from '@abp/ng.core';

describe('SimpleCMSService', () => {
  let service: SimpleCMSService;
  const mockRestService = jasmine.createSpyObj('RestService', ['request']);
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [
        {
          provide: RestService,
          useValue: mockRestService,
        },
      ],
    });
    service = TestBed.inject(SimpleCMSService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
