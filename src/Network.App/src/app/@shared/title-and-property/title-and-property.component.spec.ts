import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TitleAndPropertyComponent } from './title-and-property.component';

describe('TitleAndPropertyComponent', () => {
  let component: TitleAndPropertyComponent;
  let fixture: ComponentFixture<TitleAndPropertyComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TitleAndPropertyComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TitleAndPropertyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
