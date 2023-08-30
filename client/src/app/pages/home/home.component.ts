import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AccountService } from 'src/app/_services/account.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent{
  constructor(
    public accountService: AccountService,
    
  ){}
  get isLoggedIn(): boolean {
    var token = localStorage.getItem('token')
   
    if(token != null){

      return true
    }
    else{
      return false;
    }
    
    
  }
 
 
  }

