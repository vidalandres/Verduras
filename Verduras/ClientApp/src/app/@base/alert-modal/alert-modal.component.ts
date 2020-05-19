import { Component, OnInit, Input } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { Title } from '@angular/platform-browser';
import { Message } from '@angular/compiler/src/i18n/i18n_ast';

@Component({
  selector: 'app-alert-modal',
  templateUrl: './alert-modal.component.html',
  styleUrls: ['./alert-modal.component.css']
})
export class AlertModalComponent implements OnInit {

  constructor(public activeModal: NgbActiveModal) { }

  @Input() title;
  @Input() message;

  ngOnInit() {
  }

}
