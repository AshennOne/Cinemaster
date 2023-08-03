import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AccountService } from 'src/app/_services/account.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css'],
})
export class NavComponent implements OnInit {
  username:string = ""
  role = ""
 // 
  get isLoggedIn(): boolean {
    var token = localStorage.getItem('token')
    if(token != null){
     
      this.username= this.accountService.getTokenClaims(token).unique_name
      this.role=this.accountService.getTokenClaims(token).role
      return true
    }
    else{
      return false;
    }
    
    
  }

  constructor(
    public accountService: AccountService,
    private toastr: ToastrService,
    private router: Router
  ) {}
  ngOnInit(): void {}

  logout() {
    this.accountService.removeToken();
    this.toastr.success('Succesfully logged out');
    this.router.navigateByUrl('/');
  }
}
