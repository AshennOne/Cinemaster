import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Movie } from 'src/app/_models/Movie';
import { MovieService } from 'src/app/_services/movie.service';

@Component({
  selector: 'app-add-movie',
  templateUrl: './add-movie.component.html',
  styleUrls: ['./add-movie.component.css']
})
export class AddMovieComponent {
  movieForm: FormGroup;

  constructor(private movieService:MovieService, private fb:FormBuilder){
    
      this.movieForm = this.fb.group({
        title: ['', Validators.required],
        genre: ['', Validators.required],
        premiere: ['', Validators.required],
        description: ['', Validators.required],
        imgUrl: ['', Validators.required],
        duration: ['', [Validators.required,Validators.min(20),Validators.max(500)]],
      });
    
  }
  addMovie(movie:Movie){
    console.log(movie)
    this.movieService.addMovie(movie);
  }
  processForm(formGroup:FormGroup){
    
    const movie:Movie = {
      title : formGroup.get('title')?.value,
      genre : formGroup.get('genre')?.value,
      premiere : formGroup.get('premiere')?.value,
      description : formGroup.get('description')?.value,
      imgUrl : formGroup.get('imgUrl')?.value,
      duration : formGroup.get('duration')?.value
    }
    
    this.addMovie(movie);
  }
}
