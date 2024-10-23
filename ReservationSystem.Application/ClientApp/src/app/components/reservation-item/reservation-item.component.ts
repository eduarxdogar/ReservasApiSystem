import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { TranslocoService } from '@ngneat/transloco';
import { NgxStarsComponent } from 'ngx-stars';
import { Reservation } from 'src/app/models/Reservation';
import { ReservationService } from 'src/app/services/reservation.service';

@Component({
  selector: 'app-reservation-item',
  templateUrl: './reservation-item.component.html',
  styleUrls: ['./reservation-item.component.css']
})
export class ReservationItemComponent implements OnInit {
  @Input() reservation: Reservation;
  @ViewChild(NgxStarsComponent) starsComponent: NgxStarsComponent;
  activeLang: string;
  rankingLoader: boolean = false;

  constructor(private reservationService: ReservationService,
    private translator: TranslocoService) { }

  ngOnInit(): void {
    //checking on language changes to reload 'dateTranslated' pipe
    this.translator.langChanges$.subscribe(language => {
      this.activeLang = language;
    });
  }

  toggleFavorite(): void {
    this.reservation.favorite = !this.reservation.favorite;
  }

  setFavorite(): void {
    this.toggleFavorite();
    this.reservationService.updateReservation(this.reservation)
      .subscribe(
        () => { },
        () => { this.toggleFavorite() }
      );
  }

  rateReservation(rating: number) {
    this.rankingLoader = true;
    this.reservation.ranking = rating;
    this.reservationService.rateReservation(this.reservation)
      .subscribe(
        ranking => {
          this.reservation.ranking = ranking;
          this.starsComponent.setRating(ranking);
          this.rankingLoader = false;
        }
      );
  }
}
