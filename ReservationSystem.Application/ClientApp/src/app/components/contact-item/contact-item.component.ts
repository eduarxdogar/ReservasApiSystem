import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { TranslocoService } from '@ngneat/transloco';
import { Contact } from 'src/app/models/Contact';

@Component({
  selector: 'app-contact-item',
  templateUrl: './contact-item.component.html',
  styleUrls: ['./contact-item.component.css']
})
export class ContactItemComponent implements OnInit {
  @Input() contact: Contact;
  @Output() onDeleteContact: EventEmitter<any> = new EventEmitter();
  activeLang: string;

  constructor(private translator: TranslocoService) { }

  ngOnInit(): void {
    //checking on language changes to reload 'dateTranslated' pipe
    this.translator.langChanges$.subscribe(language => {
      this.activeLang = language;
    });
  }

  onDelete(contact: Contact): void {
    this.onDeleteContact.emit(contact);
  }

}
