import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GlobalMapViewComponent } from './global-map-view.component';

describe('GlobalMapViewComponent', () => {
  let component: GlobalMapViewComponent;
  let fixture: ComponentFixture<GlobalMapViewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [GlobalMapViewComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(GlobalMapViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
