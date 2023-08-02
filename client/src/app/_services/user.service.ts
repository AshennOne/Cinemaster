import { Injectable } from '@angular/core';
import { User } from '../_models/User';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  constructor(private http: HttpClient) {}
  baseUrl = environment.apiUrl;
  isLoggedIn = false
  register(user: User) {
    return this.http.post(this.baseUrl + 'auth/register', user);
  }
  login(user: User) {
    return this.http.post(this.baseUrl + 'auth/login', user);
  }
  toggleLoggedIn(){
    this.isLoggedIn = !this.isLoggedIn
  }
}
