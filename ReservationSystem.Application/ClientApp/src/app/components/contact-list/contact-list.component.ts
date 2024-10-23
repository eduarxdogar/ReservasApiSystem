import { Component, OnInit } from '@angular/core';
import { translate } from '@ngneat/transloco';
import { Contact } from 'src/app/models/Contact';
import { ContactService } from 'src/app/services/contact.service';

@Component({
  selector: 'app-contact-list',
  templateUrl: './contact-list.component.html',
  styleUrls: ['./contact-list.component.css']
})
export class ContactListComponent implements OnInit {
  contacts: Contact[] = [];
  currentPage: number = 1;
  sortOptions: string = '';
  sortAscending: boolean = true;
  sortDirection: string = '';
  sortField: string = '';

  constructor(private contactService: ContactService) { }

  ngOnInit(): void {
    this.loadContacts();
  }

  loadContacts() {
    this.contactService.getContacts().subscribe(
      (contacts) => {
        this.contacts = contacts.map(x=>{
          x.nameSortable=x.name.toLowerCase();
          x.contactTypeNameSortable=x.contactType?.name.toLowerCase()||'';
          return x;
        });
      }
    );
  }

  deleteContact(contact: Contact) {
    if (confirm(translate('contact_delete_confirm'))) {
      this.contactService.deleteContact(contact.id)
        .subscribe(() => {
          alert(translate('contact_deleted'));
          this.loadContacts();
        });
    }
  }

  sortContactsBy(field: string): void {
    if (this.sortField === field) {
      this.sortAscending = !this.sortAscending;
    }
    this.sortDirection = this.sortAscending ? 'asc' : 'desc';
    this.sortField = field;
  }
}
