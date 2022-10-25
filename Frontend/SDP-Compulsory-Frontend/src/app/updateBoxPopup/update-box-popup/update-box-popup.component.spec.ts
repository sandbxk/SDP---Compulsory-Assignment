import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateBoxPopupComponent } from './update-box-popup.component';

describe('UpdateBoxPopupComponent', () => {
  let component: UpdateBoxPopupComponent;
  let fixture: ComponentFixture<UpdateBoxPopupComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UpdateBoxPopupComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UpdateBoxPopupComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
