import { Injectable } from '@angular/core';
import { User } from '../_models/User';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { catchError, map, of, tap, throwError } from 'rxjs';
import { JwtHelperService } from '@auth0/angular-jwt';
import { UserService } from './user.service';

@Injectable({
  providedIn: 'root',
})
export class AccountService {
  private jwtHelper: JwtHelperService;
  constructor(private http: HttpClient, private userService:UserService) {
    this.jwtHelper = new JwtHelperService();
  }
  baseUrl = environment.apiUrl;
  register(user: User) {
    return this.http.post<User>(this.baseUrl + 'auth/register', user).pipe(
      tap((response) => {}),
      catchError((error: HttpErrorResponse) => {
        let errorMessage = 'An error occurred. Please try again later.';

        if (error.status === 400 && error.error) {
          errorMessage = error.error;
        }

        return throwError(() => errorMessage);
      })
    );
  }
  login(user: User) {
    return this.http.post<User>(this.baseUrl + 'auth/login', user).pipe(
      tap((response) => {}),
      catchError((error: HttpErrorResponse) => {
        let errorMessage = 'An error occurred. Please try again later.';
        if (error.status === 404) errorMessage = "username doesn't exists";
        else {
          errorMessage =
            error.status === 401
              ? 'invalid password'
              : 'an error occured, please try again';
        }
        return throwError(() => errorMessage);
      })
    );
  }
  getToken() {
    return localStorage.getItem('token');
  }
  setToken(token: string) {
    localStorage.setItem('token', token);
  }
  removeToken() {
    localStorage.removeItem('token');
    localStorage.removeItem('pageNumber')
    localStorage.removeItem('movieParams')
  }
  getTokenClaims(token: string) {
    
    return this.jwtHelper.decodeToken(token);
  

  }
 private getUserFromStorage(){
    return localStorage.getItem('user')
  }
  private  setUserFromStorage(user:User){
    localStorage.setItem('user', JSON.stringify(user))
  }
  getCurrentUser(){
    var user = this.getUserFromStorage()
    if(user) return of(JSON.parse(user) as User)
    var token = this.getToken();
  if (token) {
    var currentUserUsername =
      this.getTokenClaims(token).unique_name;
    if (currentUserUsername) {
      return this.userService.getUserByUsername(currentUserUsername).pipe(
        map ((user) =>{
          this.setUserFromStorage(user)
          return user;
        })
      )
    }
    
  }
  return of({} as User)
  }
}
