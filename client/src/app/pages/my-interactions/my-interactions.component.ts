import { Component, OnInit } from '@angular/core';
import { Movie } from 'src/app/_models/Movie';
import { User } from 'src/app/_models/User';
import { AccountService } from 'src/app/_services/account.service';
import { CommentService } from 'src/app/_services/comment.service';
import { MovieListService } from 'src/app/_services/movie-list.service';
import { MovieService } from 'src/app/_services/movie.service';
import { RatingService } from 'src/app/_services/rating.service';

@Component({
  selector: 'app-my-interactions',
  templateUrl: './my-interactions.component.html',
  styleUrls: ['./my-interactions.component.css'],
})
export class MyInteractionsComponent {
  user?: User;
  movies?:Movie[]
  constructor(private accountService: AccountService, private movieService:MovieService, private movieListService:MovieListService, private ratingService:RatingService, private commentService:CommentService) {
    this.accountService.getCurrentUser().subscribe({
      next: (user) => {
        if (user) this.user = user;
      },
    });
  }
}
