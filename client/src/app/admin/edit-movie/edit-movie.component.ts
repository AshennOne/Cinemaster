import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
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
  imageUrl?: string;
  file: File = {} as File;
  ngOnInit() {
    this.route.paramMap.subscribe((params) => {
      var title = params.get('title');
      if (title) this.movieTitle = title;
      this.movieService.getMovie(this.movieTitle).subscribe({
        next: (movie) => {
          if (movie) this.movie = movie;
        },
      });
    });
  }

  constructor(
    private toastr: ToastrService,
    private movieService: MovieService,
    private route: ActivatedRoute
  ) {}
  editMovie(movie: Movie) {
    if (this.movie) {
      this.movieService.editMovie(this.movie.id!, movie);
      this.toastr.success('Movie updated');
    }
  }
}
