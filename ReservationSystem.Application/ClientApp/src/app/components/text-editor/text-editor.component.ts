import { Component, OnInit, ViewChild } from '@angular/core';
import { ToolbarService, LinkService, ImageService, HtmlEditorService } from '@syncfusion/ej2-angular-richtexteditor';
import {  QuickToolbarService, RichTextEditorComponent } from '@syncfusion/ej2-angular-richtexteditor';

@Component({
  selector: 'app-text-editor',
  templateUrl: './text-editor.component.html',
  styleUrls: ['./text-editor.component.css'],
  providers: [ToolbarService, LinkService, ImageService, HtmlEditorService, QuickToolbarService]
})
export class TextEditorComponent implements OnInit {
  content: string;

  @ViewChild('objRTE')
  public rteObj: RichTextEditorComponent;

  constructor() { }

  ngOnInit(): void {
  }
}

