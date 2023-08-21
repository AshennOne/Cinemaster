import {
  Component,
  Input,
  OnChanges,
  OnInit,
  SimpleChanges,

} from '@angular/core';
import { Router } from '@angular/router';
import { Movie } from 'src/app/_models/Movie';
import { User } from 'src/app/_models/User';
import { CommentService } from 'src/app/_services/comment.service';

@Component({
  selector: 'app-movie-card',
  templateUrl: './movie-card.component.html',
  styleUrls: ['./movie-card.component.css'],
})
export class MovieCardComponent implements  OnChanges {
  @Input() movie?: Movie;
  @Input() user?:User
  isLiked = false;
  constructor(private router: Router) {}
  ngOnChanges(changes: SimpleChanges): void {
    if(changes['movie'] || changes['user'] ){
      this.checkIsLiked()
    }
  }
  

  checkIsLiked(){
    
    if(!this.movie || !this.user) return;
   
   this.movie.likedByUsers.forEach(element =>{
    if(element.userId == this.user?.id){
      this.isLiked = true;
    }
   
   })
  }

  shortenDescription(): string {
    if (!this.movie) return '';
    return this.movie.description.length > 85
      ? this.movie.description.slice(0, 85) + '...'
      : this.movie.description;
  }
  movieTitle() {
    if (!this.movie) return '';
    return this.movie.title.length > 29
      ? this.movie.title
      : this.movie.title + '\n';
  }
  avgRate(){
    if(!this.movie) return 0
    else{
      var sum = 0
      this.movie.ratings.forEach(element => {
        sum+= element.grade
      });
      if(sum>0){
        sum = sum/this.movie.ratings.length 
      }
      return sum;
      
    }
  }
  commentsCount(){
    return this.movie?.comments.length
  }
  redirect(movie: Movie) {
    this.router.navigateByUrl('movies/' + movie.title);
  }
  
}
