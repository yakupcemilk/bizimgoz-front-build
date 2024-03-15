import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MatricesChartComponent } from './matrices-chart.component';

describe('MatricesChartComponent', () => {
  let component: MatricesChartComponent;
  let fixture: ComponentFixture<MatricesChartComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [MatricesChartComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(MatricesChartComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
