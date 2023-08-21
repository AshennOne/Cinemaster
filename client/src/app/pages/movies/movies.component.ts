import { DatePipe } from '@angular/common';
import { Component, OnInit, TemplateRef } from '@angular/core';
import { Router } from '@angular/router';
import { BsDatepickerConfig, BsLocaleService } from 'ngx-bootstrap/datepicker';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Movie } from 'src/app/_models/Movie';
import { MovieParams } from 'src/app/_models/MovieParams';
import { CommentService } from 'src/app/_services/comment.service';
import { MovieService } from 'src/app/_services/movie.service';

@Component({
  selector: 'app-movies',
  templateUrl: './movies.component.html',
  styleUrls: ['./movies.component.css'],
})
export class MoviesComponent{
  movies?: Movie[];
  currentPage = 1;
  totalItems = this.movies?.length || 0;

  getMovies(event:any){
    this.movies = event
   
    
  }
  getTotalItems(event:any){
    this.totalItems = event
  }

  
}
