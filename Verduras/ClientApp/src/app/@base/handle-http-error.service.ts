import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';

@Injectable({
  providedIn: 'root'
 })
 export class HandleHttpErrorService {
  constructor() { }
 
  public handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
     if(error.status == "500")
        alert("Error 500 de la petición");
      if(error.status == "400")
        alert("Error 400 de la petición");
      if(error.status == "401")
        alert("Error 401 de la petición");
      
      return of(result as T);
    };
  }
}