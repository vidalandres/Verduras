import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Producto } from '../models/producto';
import { Observable } from 'rxjs';
import { HandleHttpErrorService } from '../../@base/handle-http-error.service';
import {catchError, map, tap} from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ProductoService {

  baseUrl: string;

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private handleErrorService: HandleHttpErrorService) 
  {
    this.baseUrl = baseUrl;
  }

  get(): Observable<Producto[]> {
    return this.http.get<Producto[]>('api/producto');
  }

  post(prod: Producto): Observable<Producto> {
    return this.http.post<Producto>(this.baseUrl + 'api/producto', prod);
  }

  put(prod: Producto): Observable<Producto> {    
    return this.http.put<Producto>(this.baseUrl + 'api/producto', prod);
  }

}

