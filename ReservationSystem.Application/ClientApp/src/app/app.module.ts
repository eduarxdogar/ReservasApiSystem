import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { RouterModule, Routes } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import {NgxPaginationModule} from 'ngx-pagination';
import { RichTextEditorModule } from '@syncfusion/ej2-angular-richtexteditor';
import {MatProgressSpinnerModule} from '@angular/material/progress-spinner';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {MatIconModule} from '@angular/material/icon';
import { NgxStarsModule } from 'ngx-stars';
import { TranslocoRootModule } from './transloco-root.module';

import { AppComponent } from './app.component';
import { ReservationListComponent } from './components/reservation-list/reservation-list.component';
import { ContactListComponent } from './components/contact-list/contact-list.component';
import { ContactCreateEditComponent } from './components/contact-create-edit/contact-create-edit.component';
import { ReservationCreateEditComponent } from './components/reservation-create-edit/reservation-create-edit.component';
import { ReservationItemComponent } from './components/reservation-item/reservation-item.component';
import { ContactItemComponent } from './components/contact-item/contact-item.component';
import { TextEditorComponent } from './components/text-editor/text-editor.component';
import { NavComponent } from './components/nav/nav.component';
import { ContactFormComponent } from './components/contact-form/contact-form.component';
import { PageHeaderComponent } from './components/page-header/page-header.component';
import { APP_ROUTES } from './app.routes';
import { SortPipe } from './helpers/sort.pipe';
import { FrenchDatePipe } from './helpers/date-translation.pipe';

@NgModule({
  declarations: [
    AppComponent,
    ReservationListComponent,
    ContactListComponent,
    ContactCreateEditComponent,
    ReservationCreateEditComponent,
    ReservationItemComponent,
    ContactItemComponent,
    TextEditorComponent,
    NavComponent,
    ContactFormComponent,
    PageHeaderComponent,
    SortPipe,
    FrenchDatePipe
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    AppRoutingModule,
    NgxPaginationModule,
    RouterModule.forRoot(APP_ROUTES),
    RichTextEditorModule,
    FormsModule,
    ReactiveFormsModule,
    MatProgressSpinnerModule,
    BrowserAnimationsModule,
    MatIconModule,
    NgxStarsModule,
    TranslocoRootModule,
  ],
  providers: [SortPipe,FrenchDatePipe],
  bootstrap: [AppComponent]
})

export class AppModule { }