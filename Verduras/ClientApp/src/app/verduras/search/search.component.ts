import { Component, OnInit } from '@angular/core';


import { Fruta } from '../models/fruta';
import { FrutaService } from '../services/fruta.service';
import { ClientService } from 'src/app/services/client.service';


@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent implements OnInit {

  frutas:Fruta[];
  key:string;

  constructor( private frutaSe:FrutaService, private cS:ClientService ) {
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

  save(index:number){
    this.cS.write(this.frutas[index]);
  }

}
