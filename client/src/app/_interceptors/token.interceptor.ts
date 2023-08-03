import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpErrorResponse,
} from '@angular/common/http';
import { Observable, catchError, throwError } from 'rxjs';
import { AccountService } from '../_services/account.service';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';

@Injectable()
export class TokenInterceptor implements HttpInterceptor {
  constructor(
    private accountService: AccountService,
    private toastr: ToastrService,
    private router: Router
  ) {}

  intercept(
    request: HttpRequest<unknown>,
    next: HttpHandler
  ): Observable<HttpEvent<unknown>> {
    const myToken = this.accountService.getToken();
    if (myToken) {
      request = request.clone({
        setHeaders: { Authorization: 'Bearer ' + myToken },
      });
    }
    return next.handle(request).pipe(
      catchError((err: any) => {
        if (err instanceof HttpErrorResponse) {
          if (err.status === 401) {
            localStorage.removeItem('token')
            this.toastr.warning('Token has expired, log in again');
            this.router.navigateByUrl('login');
          }
        }
        return throwError(() => new Error('Undefined error occured'));
      })
    );
  }
}
