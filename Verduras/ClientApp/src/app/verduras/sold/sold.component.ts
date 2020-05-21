import { Component, OnInit } from '@angular/core';
import { Producto } from '../models/producto';
import { ProductoService } from '../services/producto.service';
import { ClientService } from 'src/app/services/client.service';
import { SellService } from '../services/sell.service';
import { Vendido } from '../models/vendido';
import { Venta } from '../models/venta';

@Component({
  selector: 'app-sold',
  templateUrl: './sold.component.html',
  styleUrls: ['./sold.component.css']
})
export class SoldComponent implements OnInit {

  productos:Producto[];
  vendidos:Venta[];
  key:string;

  constructor( private productoSe:ProductoService, private cS:ClientService, private sS:SellService) {
    this.productos = new Array<Producto>();
  }

  ngOnInit() {
    this.cargar();
  }

  cargar(){
    this.sS.get().subscribe(
      (data) => {
        console.log(data);
        this.vendidos = data;
      },
      (error) => {
        alert("Error al cosnultar");
      }
    );
  }
}
