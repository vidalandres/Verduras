import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { User } from '../seguridad/user';
import { HandleHttpErrorService } from '../@base/handle-http-error.service';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  private currentUserSubject: BehaviorSubject<User>;
  public currentUser: Observable<User>;
  baseUrl:string;

  constructor(
    private http:HttpClient,
    @Inject('BASE_URL') _baseUrl:string,
    private handleErrorService: HandleHttpErrorService
  ) { 
    this.currentUserSubject = new BehaviorSubject<User>(JSON.parse(localStorage.getItem('currentUser')));
    this.currentUser = this.currentUserSubject.asObservable();
    this.baseUrl = _baseUrl;
  }

  public get currentUserValue(): User {
    return this.currentUserSubject.value;
  }

  login(username, password){
    return this.http.post<any>(this.baseUrl+'api/login', {username, password}).pipe(map( user => {
      localStorage.setItem('currentUser',JSON.stringify(user));
      this.currentUserSubject.next(user);
      return user;
    }));
  }

  logout(){
    localStorage.removeItem('currentUser');
    this.currentUserSubject.next(null);
  }
}
