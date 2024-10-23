import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { API_URL } from 'variables';
import { Contact } from '../models/Contact';

@Injectable({
  providedIn: 'root'
})
export class ContactService {

  constructor(private http: HttpClient) { }

  getContacts(): Observable<Contact[]> {
    return this.http.get<Contact[]>(`${API_URL}/contacts`);
  }

  getContactById(id:number): Observable<Contact> {
    return this.http.get<Contact>(`${API_URL}/contacts/${id}`);
  }

  getContactByName(name: { name: string }): Observable<Contact> {
    return this.http.post<Contact>(`${API_URL}/contacts/getbyname`, name);
  }

  addContact(contact: Contact): Observable<Contact> {
    return this.http.post<Contact>(`${API_URL}/contacts`, contact);
  }

  updateContact(contact: Contact): Observable<void> {
    return this.http.put<void>(`${API_URL}/contacts/${contact.id}`, contact);
  }

  deleteContact(id?: number): Observable<void> {
    return this.http.delete<void>(`${API_URL}/contacts/${id}`);
  }
}
