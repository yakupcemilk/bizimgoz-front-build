import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SparklineGaugeComponent } from './sparkline-gauge.component';

describe('SparklineGaugeComponent', () => {
  let component: SparklineGaugeComponent;
  let fixture: ComponentFixture<SparklineGaugeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SparklineGaugeComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(SparklineGaugeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
