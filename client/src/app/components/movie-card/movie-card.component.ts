import { Component, Input } from '@angular/core';
import { Router } from '@angular/router';
import { Movie } from 'src/app/_models/Movie';

@Component({
  selector: 'app-movie-card',
  templateUrl: './movie-card.component.html',
  styleUrls: ['./movie-card.component.css']
})
export class MovieCardComponent {
  @Input() movie?:Movie

  constructor(private router:Router){}

  shortenDescription(): string {
    if(!this.movie) return ""
    return this.movie.description.length > 85
      ? this.movie.description.slice(0, 85) + '...'
      : this.movie.description;
  }
  movieTitle(){
    if(!this.movie) return ""
    return this.movie.title.length > 29
    ? this.movie.title : this.movie.title + '\n'
  }
  redirect(movie:Movie){
    this.router.navigateByUrl('movies/'+ movie.title)
    
  }
}
