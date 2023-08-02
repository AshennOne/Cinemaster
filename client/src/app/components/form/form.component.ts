import {
  Component,
  EventEmitter,
  Input,
  OnChanges,
  OnInit,
  Output,
  SimpleChanges,
} from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Movie } from 'src/app/_models/Movie';
import { CloudinaryService } from 'src/app/_services/cloudinary.service';
import { environment } from 'src/environments/environment.prod';

@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css'],
})
export class FormComponent implements OnChanges {
  @Input() formTitle: string = '';
  @Input() movie?: Movie;
  @Output() movieSubmitted: EventEmitter<Movie> = new EventEmitter<Movie>();

  movieForm = this.createForm();
  imageUrl?: string;
  file?: File 
  @Input() isAddForm = false;
  constructor(private cloudinaryService: CloudinaryService) {}
  ngOnChanges(changes: SimpleChanges) {
    if (changes['movie'] && changes['movie'].currentValue) {
      this.movie = changes['movie'].currentValue;

      if (this.movie) this.fillForm(this.movie);
    }
  }


  fillForm(movie: Movie) {
    this.movieForm.patchValue({
      title: movie.title,
      genre: movie.genre,
      premiere: new Date(movie.premiere),
      description: movie.description,
      duration: movie.duration,
    });
    this.imageUrl = movie.imgUrl;
  }

  onSubmit() {
    if (this.file) {
      if (this.imageUrl === undefined) {
        const data = new FormData();
        data.append('file', this.file);
        data.append('upload_preset', 'vkecuura');
        data.append('cloud_name', environment.cloud_name);
        this.cloudinaryService.uploadImage(data).subscribe({
          next: (res) => {
            const img = res.secure_url;
            this.imageUrl = img.replace('upload', 'upload/w_270,h_400');
            if (!this.imageUrl) return;
            this.passMovieToParent()
          },
          
        });
      }
    }else{
      this.passMovieToParent()
    }
  }

 passMovieToParent(){
  const movie: Movie = this.createMovieObj();
        this.movieSubmitted.emit(movie);
        if(this.isAddForm){
          this.movieForm.reset();
          this.imageUrl = undefined
        }else{
          this.fillForm(movie)
          
        }
        
        
        this.file = {} as File;
 }

  createMovieObj(): Movie {
    return {
      title: this.movieForm.get('title')?.value,
      genre: this.movieForm.get('genre')?.value,
      premiere: this.movieForm.get('premiere')?.value,
      description: this.movieForm.get('description')?.value,
      imgUrl: this.imageUrl,
      duration: this.movieForm.get('duration')?.value,
    } as Movie;
  }

  receiveImgFromUploader(event: any) {
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
