import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Venta } from '../models/venta';
import { Observable } from 'rxjs';
import { HandleHttpErrorService } from '../../@base/handle-http-error.service';
import {catchError, map, tap} from 'rxjs/operators';
import { Vendido } from '../models/vendido';

@Injectable({
  providedIn: 'root'
})
export class SellService {

  baseUrl: string;

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private handleErrorService: HandleHttpErrorService) 
  {
    this.baseUrl = baseUrl;
  }

  get(): Observable<Venta[]> {
    return this.http.get<Venta[]>('api/venta')
      .pipe(
        tap(_ => this.handleErrorService.log('datos recividos')),
        catchError(this.handleErrorService.handleError<Venta[]>('Consulta Venta', null))
    );
  }

  getVendido(id:number): Observable<Vendido[]> {
    return this.http.get<Vendido[]>('api/venta/'+id)
      .pipe(
        tap(_ => this.handleErrorService.log('datos recividos')),
        catchError(this.handleErrorService.handleError<Vendido[]>('Consulta Venta', null))
    );
  }

  post(venta: Venta): Observable<Venta> {
    console.log(venta);
    return this.http.post<Venta>(this.baseUrl + 'api/venta', venta)
      .pipe(
        tap(_ => this.handleErrorService.log('datos enviados')),
        catchError(this.handleErrorService.handleError<Venta>('Registrar Venta', null))
    );
  }

  put(venta: Venta): Observable<Venta> {    
    return this.http.put<Venta>(this.baseUrl + 'api/venta', venta)
      .pipe(
        tap(_ => this.handleErrorService.log('datos enviados')),
        catchError(this.handleErrorService.handleError<Venta>('Actualizar Venta', null))
    );
  }

}

