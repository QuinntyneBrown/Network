import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DatesEmployedComponent } from './dates-employed.component';

describe('DatesEmployedComponent', () => {
  let component: DatesEmployedComponent;
  let fixture: ComponentFixture<DatesEmployedComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DatesEmployedComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DatesEmployedComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
