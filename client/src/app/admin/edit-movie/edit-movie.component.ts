import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Movie } from 'src/app/_models/Movie';
import { MovieService } from 'src/app/_services/movie.service';

@Component({
  selector: 'app-edit-movie',
  templateUrl: './edit-movie.component.html',
  styleUrls: ['./edit-movie.component.css'],
})
export class EditMovieComponent implements OnInit {
  movieTitle: string = '';
  movie?: Movie;
  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private movieService: MovieService
  ) {}
  ngOnInit() {
    this.route.params.subscribe((params) => {
      this.movieTitle = params['title'];
    });
    this.movieService.getMovie(this.movieTitle).subscribe({
      next: (movie) => (this.movie = movie),
    });
  }
}
