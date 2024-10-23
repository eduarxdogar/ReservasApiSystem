import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ReservationCreateEditComponent } from './reservation-create-edit.component';

describe('ReservationCreateComponent', () => {
  let component: ReservationCreateEditComponent;
  let fixture: ComponentFixture<ReservationCreateEditComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ReservationCreateEditComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ReservationCreateEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
