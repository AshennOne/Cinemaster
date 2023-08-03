import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { AccountService } from '../_services/account.service';
import { ToastrService } from 'ngx-toastr';

@Injectable({
  providedIn: 'root',
})
export class AuthGuard implements CanActivate {
  constructor(
    private accountService: AccountService,
    private toastr: ToastrService,
    private router: Router
  ) {}
  canActivate(): boolean {
    if (
      this.accountService.getToken() !== null &&
      this.accountService.getToken() !== undefined
    ) {
      return true;
    } else {
      this.toastr.error('Permission denied. Please log in first!');
      this.router.navigateByUrl('login');
      return false;
    }
  }
}
