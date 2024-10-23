import { Routes } from "@angular/router";
import { ContactCreateEditComponent } from "./components/contact-create-edit/contact-create-edit.component";
import { ContactListComponent } from "./components/contact-list/contact-list.component";
import { ReservationCreateEditComponent } from "./components/reservation-create-edit/reservation-create-edit.component";
import { ReservationListComponent } from "./components/reservation-list/reservation-list.component";

export const APP_ROUTES: Routes  = [
    { path: '', component: ReservationListComponent },
    { path: 'reservations', component: ReservationListComponent },
    { path: 'reservations/create', component: ReservationCreateEditComponent },
    { path: 'reservations/edit/:id', component: ReservationCreateEditComponent },
    { path: 'contacts', component: ContactListComponent },
    { path: 'contacts/create', component: ContactCreateEditComponent },
    { path: 'contacts/edit/:id', component: ContactCreateEditComponent },
  ];