import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { translate } from '@ngneat/transloco';
import { Contact } from 'src/app/models/Contact';
import { ContactService } from 'src/app/services/contact.service';
import { ContactFormComponent } from '../contact-form/contact-form.component';

@Component({
  selector: 'app-contact-create-edit',
  templateUrl: './contact-create-edit.component.html',
  styleUrls: ['./contact-create-edit.component.css']
})
export class ContactCreateEditComponent implements OnInit {
  @ViewChild(ContactFormComponent) contactForm: ContactFormComponent;
  contactId?: number;

  checkInputs: boolean = false;

  constructor(
    private contactService: ContactService,
    private route: ActivatedRoute) { }

  ngOnInit(): void {
    //get contact id from url
    this.contactId = Number(this.route.snapshot.paramMap.get('id'));
    if (this.contactId) {
      this.contactService.getContactById(this.contactId)
        .subscribe((contact: Contact) => {
          this.contactForm.contactIdControl.setValue(contact.id);
          this.contactForm.nameControl.setValue(contact.name);
          this.contactForm.contactTypeIdControl.setValue(contact.contactTypeId);
          this.contactForm.phoneControl.setValue(contact.phone);
          const date=new Date(contact.birthDate);
          const dateString= `${date.getDate()}/${date.getMonth()+1}/${date.getFullYear()}`;
          this.contactForm.birthDateControl.setValue(dateString);
        });
    }
  }

  onSubmit(): void {
    if (!this.contactForm.formGroup.valid) {
      this.checkInputs = true;
      return;
    }
    (this.contactForm.contactIdControl.value)
      ? this.editContact()
      : this.addContact();
  }

  addContact(): void {
    this.contactService.addContact({
      name: this.contactForm.nameControl.value,
      contactTypeId: this.contactForm.contactTypeIdControl.value,
      phone: this.contactForm.phoneControl.value,
      birthDate: this.contactForm.birthDateControl.value
    })
      .subscribe((data) => {
        console.log(data);
        alert(translate('contact_created'));
        this.contactForm.clear();
      });
  }
  editContact(): void {
    this.contactService.updateContact({
      id: this.contactForm.contactIdControl.value,
      name: this.contactForm.nameControl.value,
      contactTypeId: this.contactForm.contactTypeIdControl.value,
      phone: this.contactForm.phoneControl.value,
      birthDate: this.contactForm.birthDateControl.value
    })
      .subscribe(() => {
        alert(translate('contact_updated'));
        this.contactForm.clear();
      });
  }
}
