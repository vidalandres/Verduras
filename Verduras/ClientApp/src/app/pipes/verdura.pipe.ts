import { Pipe, PipeTransform } from '@angular/core';
import { Fruta } from '../verduras/models/fruta';

@Pipe({
  name: 'verdura'
})
export class VerduraPipe implements PipeTransform {

  transform(value: Fruta[], key:string): any {
    console.log(value);
    if(key==null)
      return value;
      key=key.toLowerCase();
    return value.filter( x => x.nombre.toLowerCase().includes(key) );
  }

}
