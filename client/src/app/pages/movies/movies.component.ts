import { DatePipe } from '@angular/common';
import { Component, OnInit, TemplateRef } from '@angular/core';
import { Router } from '@angular/router';
import { BsDatepickerConfig, BsLocaleService } from 'ngx-bootstrap/datepicker';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Movie } from 'src/app/_models/Movie';
import { MovieParams } from 'src/app/_models/MovieParams';
import { User } from 'src/app/_models/User';
import { AccountService } from 'src/app/_services/account.service';
import { CommentService } from 'src/app/_services/comment.service';
import { MovieService } from 'src/app/_services/movie.service';
import { UserService } from 'src/app/_services/user.service';

@Component({
  selector: 'app-movies',
  templateUrl: './movies.component.html',
  styleUrls: ['./movies.component.css'],
})
export class MoviesComponent{
  movies?: Movie[];
  currentPage = this.getCurrentPage()
  totalItems = this.movies?.length || 0;
user?:User;
constructor(private accountService:AccountService, private userService:UserService){
  this.getUser()
}
  getCurrentPage(){
    if(localStorage.getItem('pageNumber')==null){
      return 1
    }else{
      return Number(localStorage.getItem('pageNumber'))
    }
  }
getUser() {
  if (this.user) return;
  this.accountService.getCurrentUser().subscribe({
    next:(user) => this.user = user
  })
}

  getMovies(event:any){
    this.movies = event
   
    
  }
  getTotalItems(event:any){
    this.totalItems = event
  }

  
}
