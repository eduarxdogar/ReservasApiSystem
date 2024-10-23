import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-page-header',
  templateUrl: './page-header.component.html',
  styleUrls: ['./page-header.component.css']
})
export class PageHeaderComponent implements OnInit {
  @Input() title: string = 'Page Title';
  @Input() description: string = `Lorem ipsum dolor sit amet, consectetur adipiscing elit, 
  sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.`;
  @Input() goToUrl: string = '/';
  @Input() goToLabel: string = 'Next page';

  constructor() { }

  ngOnInit(): void {
  }

}
