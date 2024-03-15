import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BoxChartComponent } from './box-chart.component';

describe('BoxChartComponent', () => {
  let component: BoxChartComponent;
  let fixture: ComponentFixture<BoxChartComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [BoxChartComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(BoxChartComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
