import { Component, OnInit } from '@angular/core';


import { Producto } from '../models/producto';
import { ProductoService } from '../services/producto.service';
import { ClientService } from 'src/app/services/client.service';


@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent implements OnInit {

  productos:Producto[];
  key:string;

  constructor( private productoSe:ProductoService, private cS:ClientService ) {
    this.productos = new Array<Producto>();
  }

  ngOnInit() {
    this.productoSe.get().subscribe (
      (data) => {
        if(data==null){
          this.productos = new Array<Producto>();
          this.productos.push(new Producto);
        }
        else {
          this.productos = data;
        }
      }
    );
  }

  save(index:number){
    this.cS.write(this.productos[index]);
  }

}
