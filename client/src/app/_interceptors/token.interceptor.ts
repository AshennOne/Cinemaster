import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpErrorResponse,
} from '@angular/common/http';
import { Observable, catchError, delay, finalize } from 'rxjs';
import { AccountService } from '../_services/account.service';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { LoadingService } from '../_services/loading.service';

@Injectable()
export class TokenInterceptor implements HttpInterceptor {
  constructor(
    private accountService: AccountService,
    private toastr: ToastrService,
    private router: Router,
    private loadingService: LoadingService
  ) {}

  intercept(
    request: HttpRequest<unknown>,
    next: HttpHandler
  ): Observable<HttpEvent<unknown>> {
   this.loadingService.showLoading();
    const myToken = this.accountService.getToken();
    if (myToken) {
      request = request.clone({
        setHeaders: { Authorization: 'Bearer ' + myToken },
      });
    }
    return next.handle(request).pipe(
      delay(1000),
      catchError((err: any) => {
        if (err instanceof HttpErrorResponse) {
          if (err.status === 401) {
            this.accountService.removeToken()
            this.toastr.warning('Token has expired, log in again');
            this.router.navigateByUrl('login');
          }
        }
        throw err;
      }),
      finalize(() => {
       this.loadingService.hideLoading();
      })
    );
  }
}
