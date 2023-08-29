import { Component } from '@angular/core';
import { Movie } from 'src/app/_models/Movie';
import { MovieService } from 'src/app/_services/movie.service';

@Component({
  selector: 'app-ranking',
  templateUrl: './ranking.component.html',
  styleUrls: ['./ranking.component.css']
})
export class RankingComponent {
  currentPage =1;
  totalItems= 0
  loaded = false;
  movies:Movie[] = []
  constructor(private movieService:MovieService){
  this.getMovies()
  }
  getMovies(){
    this.movieService.getMoviesRanking(this.currentPage).subscribe({
      next:(res) => {
        this.movies = res.movies
        this.totalItems = res.totalItems
        this.loaded = true;
       var num = 1 + 8*(this.currentPage-1)
        this.movies.forEach(element =>{
          console.log(element)
          element.rank = num;
          num++;
        })
      }
    })
  }
}
