import { Injectable } from '@angular/core';
import { Fruta } from '../verduras/models/fruta';

@Injectable({
  providedIn: 'root'
})
export class ClientService {
  write(data:Fruta){
    localStorage.clear();
    localStorage.setItem('frt', JSON.stringify(data));
    //SE ESCRIBIRÄ EL TOKEN EN CACHE O LOCALSTORAGE
  }

  read():Fruta{
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
