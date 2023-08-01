import { Component, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { Movie } from 'src/app/_models/Movie';
import { CloudinaryService } from 'src/app/_services/cloudinary.service';
import { MovieService } from 'src/app/_services/movie.service';
import { environment } from 'src/environments/environment.prod';
@Component({
  selector: 'app-add-movie',
  templateUrl: './add-movie.component.html',
  styleUrls: ['./add-movie.component.css'],
})
export class AddMovieComponent implements OnInit {
  movieForm = this.createForm()
  imageUrl?: string;
  file: File = {} as File;
  ngOnInit() {
   
  }
  constructor(
    private toastr: ToastrService,
    private movieService: MovieService,
    private cloudinaryService: CloudinaryService
  ) {}
  addMovie(movie: Movie) {
    this.movieService.addMovie(movie);
  }
  processForm(formGroup: FormGroup) {
    const data = new FormData();
    data.append('file', this.file);
    data.append('upload_preset', 'vkecuura');
    data.append('cloud_name', environment.cloud_name);
    this.cloudinaryService.uploadImage(data).subscribe({
      next: (res) => {
        var url = res.secure_url;
        url = url.replace('upload', 'upload/w_270,h_400');
        const movie: Movie = {
          title: formGroup.get('title')?.value,
          genre: formGroup.get('genre')?.value,
          premiere: formGroup.get('premiere')?.value,
          description: formGroup.get('description')?.value,
          imgUrl: url,
          duration: formGroup.get('duration')?.value,
        };

        this.movieService.addMovie(movie);
        this.toastr.success('Movie added');
        this.movieForm.reset();
        this.file = {} as File
      },
    });
  }
  receiveData(event: any) {
    this.file = event as File;
    
  }


  createForm(){
    return new FormGroup({
      title: new FormControl('', [Validators.required, Validators.maxLength(20), Validators.minLength(2)]),
      genre: new FormControl('', [Validators.required, Validators.maxLength(12), Validators.minLength(3)]),
      premiere: new FormControl(new Date(), [Validators.required]),
      description: new FormControl('', [Validators.required]),
      duration: new FormControl(0, [
        Validators.required,
        Validators.min(20),
        Validators.max(500),
      ]),
    });
  }
}
