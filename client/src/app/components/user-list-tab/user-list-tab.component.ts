import { Component, Input } from '@angular/core';
import { MovieList } from 'src/app/_models/MovieList';
import { MovieListService } from 'src/app/_services/movie-list.service';

@Component({
  selector: 'app-user-list-tab',
  templateUrl: './user-list-tab.component.html',
  styleUrls: ['./user-list-tab.component.css']
})
export class UserListTabComponent {
  movieList :MovieList[] = []
  loaded = false;
  totalItems = 0
  currentPage = 1
  constructor(private movieListService:MovieListService){
    this.getMovieList()
  }
  getMovieList(){
    this.movieListService.getPaginatedUserList(this.currentPage).subscribe ({
      next:(list)=>{
     
        this.movieList = list.userList
        this.totalItems = list.totalItems
        this.loaded = true
      }
    })
  }
 }
