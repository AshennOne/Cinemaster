import { Injectable } from '@angular/core';
import {
  CanActivate,
  Router,
} from '@angular/router';
import { AccountService } from '../_services/account.service';
import { ToastrService } from 'ngx-toastr';

@Injectable({
  providedIn: 'root',
})
export class AntiAuthGuard implements CanActivate {
  constructor(
    private accountService: AccountService,
    private toastr: ToastrService,
    private router: Router
  ) {}
  canActivate(): boolean {
    if (
      this.accountService.getToken() === null ||
      this.accountService.getToken() === undefined
    ) {
      return true;
    } else {
      this.router.navigateByUrl('movies');
      return false;
    }
  }
}
