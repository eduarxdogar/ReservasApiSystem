import { Component, OnInit, ViewChild } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { translate } from '@ngneat/transloco';
import { Reservation } from 'src/app/models/Reservation';
import { ContactService } from 'src/app/services/contact.service';
import { ReservationService } from 'src/app/services/reservation.service';
import { ContactFormComponent } from '../contact-form/contact-form.component';
import { TextEditorComponent } from '../text-editor/text-editor.component';

@Component({
  selector: 'app-reservation-create-edit',
  templateUrl: './reservation-create-edit.component.html',
  styleUrls: ['./reservation-create-edit.component.css']
})
export class ReservationCreateEditComponent implements OnInit {
  @ViewChild(TextEditorComponent) editor: TextEditorComponent;
  @ViewChild(ContactFormComponent) contactForm: ContactFormComponent;
  reservationId?: number;
  today: Date = new Date();
  dateInputType: string = 'text';

  formGroup: FormGroup;
  reservationDateControl: AbstractControl;

  checkInputs: boolean = false;

  constructor(
    private reservationService: ReservationService,
    private contactService: ContactService,
    private route: ActivatedRoute,
    private fb: FormBuilder) { }

  ngOnInit(): void {
    //set contact form group for input validation
    this.formGroup = this.fb.group({
      reservationDate: ['', [Validators.required]]
    });
    this.reservationDateControl = this.formGroup.controls['reservationDate'];
    //get id from url and load reservation if necessary
    this.reservationId = Number(this.route.snapshot.paramMap.get('id'));
    if (this.reservationId) {
      this.reservationService.getReservationById(this.reservationId)
        .subscribe((reservation: Reservation) => {
          this.contactForm.contactIdControl.setValue(reservation.contactId);
          this.contactForm.nameControl.setValue(reservation.contact?.name);
          this.contactForm.contactTypeIdControl.setValue(reservation.contact?.contactTypeId);
          this.contactForm.phoneControl.setValue(reservation.contact?.phone);
          const date = new Date(reservation.contact?.birthDate || '');
          const dateString = `${date.getDate()}/${date.getMonth() + 1}/${date.getFullYear()}`;
          this.contactForm.birthDateControl.setValue(dateString);
          this.editor.rteObj.value = reservation.description || '';
        });
    }
  }

  onSubmit(): void {
    if (!this.formGroup.valid) {
      this.checkInputs = true;
      return;
    }
    if (this.contactForm.contactIdControl.value) {
      this.contactService.updateContact({
        id: this.contactForm.contactIdControl.value,
        name: this.contactForm.nameControl.value,
        contactTypeId: this.contactForm.contactTypeIdControl.value,
        birthDate: this.contactForm.birthDateControl.value,
        phone: this.contactForm.phoneControl.value,
      }).subscribe(() => {
        this.reservationMethod();
      });
    }
    else {
      this.contactService.addContact({
        name: this.contactForm.nameControl.value,
        contactTypeId: this.contactForm.contactTypeIdControl.value,
        birthDate: this.contactForm.birthDateControl.value,
        phone: this.contactForm.phoneControl.value,
      }).subscribe((contact) => {
        this.contactForm.contactIdControl.setValue(contact.id);
        this.reservationMethod();
      });
    }
  }

  reservationMethod(): void {
    (this.reservationId)
      ? this.editReservation()
      : this.addReservation();
  }

  addReservation(): void {
    this.reservationService.addReservation({
      description: this.editor.rteObj.value,
      date: this.reservationDateControl.value,
      contactId: this.contactForm.contactIdControl.value
    })
      .subscribe((data) => {
        console.log(data);
        this.clearForm();
        this.editor.rteObj.value = '';
        this.checkInputs = false;
        alert(translate('reservation_created'));
      },
        (error) => {
          alert(error);
        });
  }
  editReservation(): void {
    this.reservationService.updateReservation({
      id: this.reservationId,
      description: this.editor.rteObj.value,
      date: this.reservationDateControl.value,
      contactId: this.contactForm.contactIdControl.value,
      contact: {
        name: this.contactForm.nameControl.value,
        contactTypeId: this.contactForm.contactTypeIdControl.value,
        birthDate: this.contactForm.birthDateControl.value,
        phone: this.contactForm.phoneControl.value
      }
    })
      .subscribe(() => {
        alert(translate('reservation_updated'));
        this.clearForm();
        this.editor.rteObj.value = '';
      });
  }

  clearForm(): void {
    this.contactForm.clear();
    this.reservationDateControl.setValue('');
    this.dateInputType = 'text';
    this.checkInputs = false;
  }
}
