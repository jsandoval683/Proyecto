import { Injectable, Inject } from '@angular/core';
import { Signup } from '../models/signup.model';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

const httpOption = {
  headers: new HttpHeaders({
    'Contend-Type': 'application/json'
  })
};

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  url: string='https://localhost:44353/api/accounts';

  constructor(
    private _http: HttpClient
  ) { }

  // add(user: Signup): Observable<Signup> {
  //   return this._http.post<Signup>(this.url, user, httpOption);
  // }

  signupUser(user: Signup) {
    console.log(user)
    console.log(this.url)
    return this._http.post(this.url, user, httpOption)
      .subscribe(data => {
        console.log(data, " this is what we got form server...")
      })
  }
  // loginUser(user: Login{
  //   console.log(user)
  // }
}