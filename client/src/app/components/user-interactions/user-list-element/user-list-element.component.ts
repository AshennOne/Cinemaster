import { Component, Input, OnChanges, SimpleChanges } from '@angular/core';
import { Router } from '@angular/router';
import { Movie } from 'src/app/_models/Movie';
import { MovieList } from 'src/app/_models/MovieList';
import { MovieService } from 'src/app/_services/movie.service';

@Component({
  selector: 'app-user-list-element',
  templateUrl: './user-list-element.component.html',
  styleUrls: ['./user-list-element.component.css']
})
export class UserListElementComponent implements OnChanges{
movie?:Movie
@Input() element? :MovieList
isHovering: boolean = false;
constructor(private movieService:MovieService,private router:Router){

}

updateList(){
  this.movie = undefined
  this.element = undefined
}
ngOnChanges(changes: SimpleChanges): void {
 if(changes['element']&& this.element){

  this.movieService.getMovieById(this.element.movieId).subscribe({
    next:(movie) => {
     
      this.movie = movie
    }
  })
 }
}
redirect(){
  this.router.navigateByUrl('movies/' + this.movie?.title);
}
}
