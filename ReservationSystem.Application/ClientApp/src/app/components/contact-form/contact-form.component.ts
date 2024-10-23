import { getLocaleDateFormat } from '@angular/common';
import { Component, Input, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Subject, takeUntil } from 'rxjs';
import { ContactType } from 'src/app/models/ContactType';
import { ContactTypeService } from 'src/app/services/contact-type.service';
import { ContactService } from 'src/app/services/contact.service';
@Component({
  selector: 'app-contact-form',
  templateUrl: './contact-form.component.html',
  styleUrls: ['./contact-form.component.css']
})
export class ContactFormComponent implements OnInit {
  birthDate: string;
  contactTypes: ContactType[];
  searchingContact: boolean = false;
  today: Date = new Date();
  formGroup: FormGroup;
  contactIdControl: AbstractControl;
  nameControl: AbstractControl;
  contactTypeIdControl: AbstractControl;
  phoneControl: AbstractControl;
  birthDateControl: AbstractControl;
  protected ngUnsubscribe: Subject<void> = new Subject<void>();
  @Input() checkInputs: boolean;
  dateInputType:string='text';

  constructor(
    private contactService: ContactService,
    private contactTypeService: ContactTypeService,
    private fb: FormBuilder) { }

  ngOnInit(): void {
    this.contactTypeService.getContactTypes().subscribe((types) => {
      this.contactTypes = types;
    });
    this.formGroup = this.fb.group({
      contactId: [null],
      name: ['', [Validators.required]],
      contactTypeId: ['', [Validators.required]],
      phone: ['', [Validators.pattern("^[0-9]{3}-[0-9]{3}-[0-9]{3}$")]],
      birthDate: ['', [Validators.required]]
    });
    this.contactIdControl = this.formGroup.controls['contactId'];
    this.nameControl = this.formGroup.controls['name'];
    this.contactTypeIdControl = this.formGroup.controls['contactTypeId'];
    this.phoneControl = this.formGroup.controls['phone'];
    this.birthDateControl = this.formGroup.controls['birthDate'];
  }

  searchExistingContact(): void {
    this.ngUnsubscribe.next();
    this.searchingContact = true;
    this.contactService.getContactByName({ name: this.nameControl.value })
      .pipe(takeUntil(this.ngUnsubscribe))
      .subscribe((data) => {
        this.contactIdControl.setValue(data.id);
        this.contactTypeIdControl.setValue(data.contactTypeId);
        this.phoneControl.setValue(data.phone);
        const date=new Date(data.birthDate);
        const dateString= `${date.getDate()}/${date.getMonth()+1}/${date.getFullYear()}`;
        this.birthDateControl.setValue(dateString);
        this.ngUnsubscribe.next();
        this.searchingContact = false;
      },
        (err) => {
          console.log(err);
          this.ngUnsubscribe.next();
          this.searchingContact = false;
          this.clearAutocompletion();
        },
        () => {
          //tryed to unsuscribe here, but somehow doesn't hit the complete statement
        });
  }

  clear(): void {
    this.nameControl.setValue('');
    this.contactIdControl.setValue(null);
    this.phoneControl.setValue('');
    this.birthDateControl.setValue('');
    this.dateInputType='text';
    this.contactTypeIdControl.setValue('');
    this.checkInputs = false;
  }
  clearAutocompletion(): void {
    this.contactIdControl.setValue(null);
    this.phoneControl.setValue('');
    this.birthDateControl.setValue('');
    this.dateInputType='text';
    this.contactTypeIdControl.setValue('');
    this.checkInputs = false;
  }

  //Input validation
  phoneKeyPress(event: any) {
    const pattern = /[0-9\+\-\ ]/;

    let inputChar = String.fromCharCode(event.charCode);
    if (event.keyCode != 8 && !pattern.test(inputChar)) {
      event.preventDefault();
    }
  }
}
