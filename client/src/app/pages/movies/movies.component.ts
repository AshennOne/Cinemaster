import { Component, OnInit } from '@angular/core';
import { Movie } from 'src/app/_models/Movie';
import { CommentService } from 'src/app/_services/comment.service';
import { MovieService } from 'src/app/_services/movie.service';

@Component({
  selector: 'app-movies',
  templateUrl: './movies.component.html',
  styleUrls: ['./movies.component.css'],
})
export class MoviesComponent implements OnInit {
  movies: Movie[] = [];
  currentPage = 1
  totalItems = 0
  constructor(private movieService: MovieService) {}
  ngOnInit(): void {
    this.GetMovies();
  }
  GetMovies() {
    this.movieService.getMovies(this.currentPage).subscribe({
      next: (pagination) => {
        this.movies = pagination.movies;
        this.totalItems = pagination.totalItems
      },
    });
    
  }
  onChangePage(){
    this.GetMovies()
  }
}
