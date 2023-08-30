import { Component, EventEmitter, Input, OnChanges, Output, SimpleChanges } from '@angular/core';
import { Router } from '@angular/router';
import { TimeagoPipe } from 'ngx-timeago';
import { Movie } from 'src/app/_models/Movie';
import { Rating } from 'src/app/_models/Rating';
import { MovieService } from 'src/app/_services/movie.service';

@Component({
  selector: 'app-user-rating',
  templateUrl: './user-rating.component.html',
  styleUrls: ['./user-rating.component.css']
})
export class UserRatingComponent implements OnChanges{
 @Input() rating?:Rating
 @Output() ratingToUpdate = new EventEmitter<Rating>();
 movie?:Movie
 isHovering: boolean = false;
constructor(private movieService:MovieService, private router:Router){}  

 ngOnChanges(changes: SimpleChanges): void {
  if (changes['rating'] && this.rating?.id && !this.movie) {
  
      this.movieService.getMovieById(this.rating.movieId).subscribe({
        next: (movie) => {
          this.movie = movie;
          
        },
      });
  }
}
unlockButton(event:number){
  if(!this.rating?.grade) return;
  this.rating.grade = event
  this.ratingToUpdate.emit(this.rating)
}
redirect(){
  this.router.navigateByUrl('movies/' + this.movie?.title);
}
}
