import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Movie } from 'src/app/_models/Movie';
import { MovieService } from 'src/app/_services/movie.service';
@Component({
  selector: 'app-add-movie',
  templateUrl: './add-movie.component.html',
  styleUrls: ['./add-movie.component.css'],
})
export class AddMovieComponent implements OnInit {
  imageUrl?: string;
  file: File = {} as File;
  ngOnInit() {}
  constructor(
    private toastr: ToastrService,
    private movieService: MovieService
  ) {}
  addMovie(movie: Movie) {
    this.movieService.addMovie(movie);
    this.toastr.success('Movie added');
  }
}
