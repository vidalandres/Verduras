import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Fruta } from '../models/fruta';
import { Observable } from 'rxjs';
import { HandleHttpErrorService } from '../../@base/handle-http-error.service';
import {catchError, map, tap} from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class FrutaService {

  baseUrl: string;

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private handleErrorService: HandleHttpErrorService) 
  {
    this.baseUrl = baseUrl;
  }

  get(): Observable<Fruta[]> {
    return this.http.get<Fruta[]>('api/fruta')
      .pipe(
        tap(_ => this.handleErrorService.log('datos recividos')),
        catchError(this.handleErrorService.handleError<Fruta[]>('Consulta Fruta', null))
    );
  }
  post(liq: Fruta): Observable<Fruta> {
    return this.http.post<Fruta>(this.baseUrl + 'api/fruta', liq)
      .pipe(
        tap(_ => this.handleErrorService.log('datos enviados')),
        catchError(this.handleErrorService.handleError<Fruta>('Registrar Fruta', null))
    );
  }

}

