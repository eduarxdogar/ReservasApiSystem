import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { API_URL } from 'variables';
import { ContactType } from '../models/ContactType';

@Injectable({
  providedIn: 'root'
})
export class ContactTypeService {

  constructor(private http:HttpClient) { }

  getContactTypes(): Observable<ContactType[]>{
    return this.http.get<ContactType[]>(`${API_URL}/contacttypes`);
  }
}
