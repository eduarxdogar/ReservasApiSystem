import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { TranslocoService } from '@ngneat/transloco';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title: string;
  url: string;
  availableLangs: string[] | { id: string, label: string }[];
  activeLang: string;

  constructor(private router: Router, private translator: TranslocoService) {
    router.events.subscribe((val) => {
      this.url = this.router.url;
    });
    this.title = 'ClientApp';
  }

  ngOnInit(): void {
    this.activeLang = this.translator.getActiveLang();
    this.availableLangs = this.translator.getAvailableLangs();
  }

  changeLang(lang: string) {
    this.translator.setActiveLang(lang);
    this.activeLang = lang;    
  }
}
