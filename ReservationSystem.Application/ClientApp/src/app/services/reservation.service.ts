import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { API_URL } from 'variables';
import { Reservation } from '../models/Reservation';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
  }),
};
@Injectable({
  providedIn: 'root'
})
export class ReservationService {

  constructor(private http: HttpClient) { }

  getReservations(): Observable<Reservation[]> {
    return this.http.get<Reservation[]>(`${API_URL}/reservations`);
  }

  getReservationById(id: number): Observable<Reservation> {
    return this.http.get<Reservation>(`${API_URL}/reservations/${id}`);
  }

  addReservation(reservation: Reservation): Observable<Reservation> {
    return this.http.post<Reservation>(`${API_URL}/reservations`, reservation, httpOptions);
  }

  updateReservation(reservation: Reservation): Observable<void> {
    return this.http.put<void>(`${API_URL}/reservations/${reservation.id}`, reservation, httpOptions);
  }

  rateReservation(reservation: Reservation): Observable<number> {
    return this.http.post<number>(`${API_URL}/reservations/rate`, reservation, httpOptions);
  }
}
