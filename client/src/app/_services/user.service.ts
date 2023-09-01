import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { User } from '../_models/User';
import { environment } from 'src/environments/environment';
import { of } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  baseUrl = environment.apiUrl;
  constructor(private http: HttpClient) {}
  getUserById(id: number) {
    var user = localStorage.getItem('User')
    if(user) return of(JSON.parse(user))
    return this.http.get<User>(this.baseUrl + 'users?id='+ id);
  }
  getUserByUsername(username: string) {
    var user = localStorage.getItem('User')
    if(user) return of(JSON.parse(user))
    return this.http.get<User>(this.baseUrl + 'users/'+ username);
  }
}
