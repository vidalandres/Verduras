import { Component, OnInit } from '@angular/core';
import { Fruta } from '../models/fruta';

import { FrutaService } from '../services/fruta.service';


@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent implements OnInit {

  frutas:Fruta[];

  constructor( private frutaSe:FrutaService ) {
    this.frutas = new Array<Fruta>();
  }

  ngOnInit() {
    this.frutaSe.get().subscribe (
      (data) => {
        if(data==null){
          this.frutas = new Array<Fruta>();
          this.frutas.push(new Fruta);
        }
        else {
          this.frutas = data;
        }
      }
    );
  }

}
