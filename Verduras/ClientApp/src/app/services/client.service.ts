import { Injectable } from '@angular/core';
import { Producto } from '../verduras/models/producto';

@Injectable({
  providedIn: 'root'
})
export class ClientService {
  write(data:Producto){
    localStorage.clear();
    localStorage.setItem('frt', JSON.stringify(data));
    //SE ESCRIBIRÄ EL TOKEN EN CACHE O LOCALSTORAGE
  }

  read():Producto{
    if(null==localStorage.getItem('frt'))
      location.pathname='';
    return JSON.parse(localStorage.getItem('frt'));
    //SE DEVOLVERÄ EL CLIENTE ALAMCENADO
  }

  clear():void{
    localStorage.clear();
    location.pathname='';
  }
}
