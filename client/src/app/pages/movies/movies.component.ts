import { Component, OnInit } from '@angular/core';
import { Movie } from 'src/app/_models/Movie';
import { MovieService } from 'src/app/_services/movie.service';

@Component({
  selector: 'app-movies',
  templateUrl: './movies.component.html',
  styleUrls: ['./movies.component.css'],
})
export class MoviesComponent implements OnInit {
  movies: Movie[] = [];
  constructor(private movieService: MovieService) {}
  ngOnInit(): void {
    this.GetMovies();
  }
  GetMovies() {
    this.movieService.getMovies().subscribe({
      next: (movies) => {
        this.movies = movies;
      },
    });
  }
}
