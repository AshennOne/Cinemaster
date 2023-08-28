import { Component } from '@angular/core';
import { Rating } from 'src/app/_models/Rating';
import { RatingService } from 'src/app/_services/rating.service';

@Component({
  selector: 'app-user-ratings-tab',
  templateUrl: './user-ratings-tab.component.html',
  styleUrls: ['./user-ratings-tab.component.css']
})
export class UserRatingsTabComponent {
  ratings: Rating[] = []
  totalItems = 0
  loaded = false
  currentPage = 1
  constructor( private ratingService:RatingService){
    this.getRatings();
   
  }
  onChangePage(){
this.getRatings()
  }
  getRatings(){
    this.ratingService.getAllUserRatings(this.currentPage).subscribe({
      next:(ratings) =>{
        this.ratings = ratings.ratings
        this.totalItems = ratings.totalItems
        this.loaded = true
      }
    })
  }
  updateRating(event:any){
    this.ratingService.editRating(event.movieId, event.grade).subscribe({
      next:()=>{
        this.getRatings()
      }
    })
  }
}
