import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Movie } from 'src/app/_models/Movie';
import { CloudinaryService } from 'src/app/_services/cloudinary.service';
import { MovieService } from 'src/app/_services/movie.service';
import { environment } from 'src/environments/environment.prod';

@Component({
  selector: 'app-edit-movie',
  templateUrl: './edit-movie.component.html',
  styleUrls: ['./edit-movie.component.css'],
})
export class EditMovieComponent implements OnInit {
  movieTitle: string = '';
  movie?: Movie;
  movieForm = this.createForm();
  imageUrl?: string;
  file: File = {} as File;
  ngOnInit() {
    this.route.paramMap.subscribe((params) => {
      var title = params.get('title');
      if (title) this.movieTitle = title;
    });

    this.movieService.getMovie(this.movieTitle).subscribe({
      next: (movie) => {
        this.movie = movie;
        this.fillForm(movie)
        // Set form values after the movie is retrieved
        if (this.movie) {
          
          this.imageUrl = this.movie.imgUrl;
        }
      },
    });
  }

  fillForm(movie:Movie){
    if(!this.movie) return;
    this.movieForm.patchValue({
      title: movie.title,
      genre: movie.genre,
      premiere: new Date(movie.premiere),
      description: movie.description,
      duration: movie.duration,
    });
  }

  constructor(
    private toastr: ToastrService,
    private movieService: MovieService,
    private cloudinaryService: CloudinaryService,
    private route: ActivatedRoute
  ) {}
  editMovie(movie: Movie) {
    this.movieService.addMovie(movie);
  }
  processForm(formGroup: FormGroup) {
    if (this.imageUrl == undefined) {
      const data = new FormData();
      data.append('file', this.file);
      data.append('upload_preset', 'vkecuura');
      data.append('cloud_name', environment.cloud_name);
      this.cloudinaryService.uploadImage(data).subscribe({
        next: (res) => {
          var img = res.secure_url;
          this.imageUrl = img.replace('upload', 'upload/w_270,h_400');
          if (!this.imageUrl) return;
          const movie: Movie = this.createMovieObj(formGroup)
          if (this.movie == undefined) return;
          this.movieService.editMovie(this.movie.id!, movie);
          this.toastr.success('Movie updated');
          this.fillForm(movie)
          this.file = {} as File;
        },
        error: (err) => console.log(err),
      });
    }
    else{
      const movie: Movie = this.createMovieObj(formGroup)
          if (this.movie == undefined) return;
          this.movieService.editMovie(this.movie.id!, movie);
          this.toastr.success('Movie updated');
          this.fillForm(movie)
          this.file = {} as File;
    }
  }

  createMovieObj(formGroup:FormGroup){
    return {
      title: formGroup.get('title')?.value,
      genre: formGroup.get('genre')?.value,
      premiere: formGroup.get('premiere')?.value,
      description: formGroup.get('description')?.value,
      imgUrl: this.imageUrl,
      duration: formGroup.get('duration')?.value,
    } as Movie
  }

  receiveData(event: any) {
    this.file = event as File;
    this.imageUrl = undefined;
  }

  createForm() {
    return new FormGroup({
      title: new FormControl('', [
        Validators.required,
        Validators.maxLength(20),
        Validators.minLength(2),
      ]),
      genre: new FormControl('', [
        Validators.required,
        Validators.maxLength(12),
        Validators.minLength(3),
      ]),
      premiere: new FormControl(new Date(1995, 11, 17), [Validators.required]),
      description: new FormControl('', [Validators.required]),
      duration: new FormControl(0, [
        Validators.required,
        Validators.min(20),
        Validators.max(500),
      ]),
    });
  }
}
