import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NewBoxPopupComponent } from './new-box-popup.component';

describe('NewBoxPopupComponent', () => {
  let component: NewBoxPopupComponent;
  let fixture: ComponentFixture<NewBoxPopupComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NewBoxPopupComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(NewBoxPopupComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
