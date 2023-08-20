import {
  Component,
  Input,
  OnChanges,
  OnInit,
  SimpleChanges,
} from '@angular/core';
import { Movie } from 'src/app/_models/Movie';
import { Rating } from 'src/app/_models/Rating';
import { User } from 'src/app/_models/User';
import { AccountService } from 'src/app/_services/account.service';
import { RatingService } from 'src/app/_services/rating.service';
import { UserService } from 'src/app/_services/user.service';

@Component({
  selector: 'app-rating',
  templateUrl: './rating.component.html',
  styleUrls: ['./rating.component.css'],
})
export class RatingComponent implements OnInit {
  rate1 = 0;
  rate2 = 0;
  rate3 = 0;
  rate4 = 0;
  rate5 = 0;
  rate = 0;
  isRated = false;
  average = 0;
  countRate = 0;
  user?: User;
  ratings: Rating[] = [];
  @Input() movie?: Movie;
  constructor(
    private ratingService: RatingService,
    private accountService: AccountService,
    private userService: UserService
  ) {}
  ngOnInit(): void {
    this.getUser();
  }
  // ngOnChanges(changes: SimpleChanges): void {
  //   if((changes['user'] || changes['movie']) && this.user && this.movie){
  //     this.getRating();
  //     this.getUser();
  //   }
  // }
  onRatingChange() {
    if (!this.movie?.id) return;
    if (!this.isRated) {
      this.ratingService.addRating(this.movie.id, this.rate).subscribe({
        next: () => {
          this.isRated = true;
          this.getRating();
        },
      });
    } else {
      this.ratingService.editRating(this.movie.id, this.rate).subscribe({
        next: () => {
          this.getRating();
        },
      });
    }
  }
  getRating() {
    this.rate1 = 0;
    this.rate2 = 0;
    this.rate3 = 0;
    this.rate4 = 0;
    this.rate5 = 0;
    this.average = 0;
    this.countRate = 0;
    if (!this.movie?.title) return;
    this.ratingService.getAllMovieRatings(this.movie.title).subscribe({
      next: (movies) => {
        movies.forEach((element) => {
          this.average += element.grade;
          if (element.userId == this.user?.id) {
            this.isRated = true;
            this.rate = element.grade;
          }
          switch (element.grade) {
            case 1:
              this.rate1 += 1;
              break;
            case 2:
              this.rate2 += 1;
              break;
            case 3:
              this.rate3 += 1;
              break;
            case 4:
              this.rate4 += 1;
              break;
            case 5:
              this.rate5 += 1;
              break;
          }
        });
          this.countRate = movies.length;
        if(this.countRate >0){
          this.average = this.average / movies.length;
      
          this.rate1 = (this.rate1 * 100) / movies.length;
          this.rate2 = (this.rate2 * 100) / movies.length;
          this.rate3 = (this.rate3 * 100) / movies.length;
          this.rate4 = (this.rate4 * 100) / movies.length;
          this.rate5 = (this.rate5 * 100) / movies.length;
        }
        
      },
    });
  }
  getUser() {
    if (this.user) return;
    var token = this.accountService.getToken();
    if (token) {
      var currentUserUsername =
        this.accountService.getTokenClaims(token).unique_name;
      if (currentUserUsername) {
        this.userService.getUserByUsername(currentUserUsername).subscribe({
          next: (user) => {
            this.user = user;
            this.getRating();
          },
        });
      }
    }
  }
}