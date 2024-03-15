import { TestBed } from '@angular/core/testing';

import { BizimgozChartsService } from './bizimgoz-charts.service';

describe('BizimgozChartsService', () => {
  let service: BizimgozChartsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(BizimgozChartsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
