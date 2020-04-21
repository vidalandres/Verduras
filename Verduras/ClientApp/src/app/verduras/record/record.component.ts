import { Component, OnInit } from '@angular/core';
import { Fruta } from '../models/fruta';

import { FrutaService } from '../services/fruta.service';

@Component({
  selector: 'app-record',
  templateUrl: './record.component.html',
  styleUrls: ['./record.component.css']
})
export class RecordComponent implements OnInit {

  fruta:Fruta;

  constructor(private frutaSe:FrutaService) { 
    this.fruta = new Fruta();
  }

  ngOnInit() {
  }

  add():void{
    this.frutaSe.post(this.fruta).subscribe(
      (data) => {
        if(data!=null) {
          alert('Guardado');
          this.fruta = data;
        }
      }
    );
  }

  clear():void{
    this.fruta = new Fruta();
  }

}
