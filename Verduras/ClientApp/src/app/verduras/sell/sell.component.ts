import { Component, OnInit } from '@angular/core';


import { Producto } from '../models/producto';
import { ProductoService } from '../services/producto.service';
import { ClientService } from 'src/app/services/client.service';
import { SellService } from '../services/sell.service';
import { Venta } from '../models/venta';
import { Usuario } from '../models/usuario';


@Component({
  selector: 'app-sell',
  templateUrl: './sell.component.html',
  styleUrls: ['./sell.component.css']
})
export class SellComponent implements OnInit {

  facts:Producto[]=new Array<Producto>();
  productos:Producto[];
  key:string;
  vendedor:Usuario = new Usuario();

  constructor( private productoSe:ProductoService, private cS:ClientService, private sS:SellService ) {
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

  add(index:number){
    this.facts.forEach(x => {
      if(x.id != this.productos[index].id)
        x.cantidad += this.productos[index].cantidad;
    });
    this.facts.push(this.productos[index]);
    console.log(this.facts);
  }

  remove(index:number){
    var select = this.facts[index];
    var temp = new Array<Producto>();
    this.facts.forEach(x => {
      if(x.id != select.id)
        temp.push(x);
    });
    this.facts = temp;
  }

  sell(){
    var venta = new Venta();
    venta.productos = this.facts;
    venta.fecha = new Date();
    venta.vendedor = this.vendedor.cedula = "1065";
    this.sS.post(venta).subscribe(
      (data) => {
        alert("Se ha vendido");
      },
      (error) => {
        alert("Error al vender");
      }
    );
  }

}
