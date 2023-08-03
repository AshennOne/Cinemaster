import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { AccountService } from '../_services/account.service';
import { ToastrService } from 'ngx-toastr';

@Injectable({
  providedIn: 'root'
})
export class AdminGuard implements CanActivate {
  constructor(private accountService:AccountService, private toastr:ToastrService, private router:Router){}
  canActivate(): boolean{
    var token = localStorage.getItem('token');
    if(!token) {
      this.toastr.error("Access denied")
      this.router.navigateByUrl('login');
      return false;
    } 
    var role = this.accountService.getTokenClaims(token).role
    if(role != "Admin"){
      this.router.navigateByUrl('movies');
      this.toastr.error("Access denied")
      return false;
    }
    return true;
  }
  
}
