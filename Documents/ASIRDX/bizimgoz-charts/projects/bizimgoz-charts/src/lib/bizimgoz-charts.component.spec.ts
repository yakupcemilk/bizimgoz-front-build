import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BizimgozChartsComponent } from './bizimgoz-charts.component';

describe('BizimgozChartsComponent', () => {
  let component: BizimgozChartsComponent;
  let fixture: ComponentFixture<BizimgozChartsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [BizimgozChartsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(BizimgozChartsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
