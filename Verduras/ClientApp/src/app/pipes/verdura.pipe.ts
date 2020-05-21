import { Pipe, PipeTransform } from '@angular/core';
import { Producto } from '../verduras/models/producto';

@Pipe({
  name: 'verdura'
})
export class VerduraPipe implements PipeTransform {

  transform(value: Producto[], key:string): any {
    console.log(value);
    if(key==null)
      return value;
      key=key.toLowerCase();
    return value.filter( x => x.nombre.toLowerCase().includes(key) );
  }

}
