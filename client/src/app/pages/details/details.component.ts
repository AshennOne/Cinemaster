import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Movie } from 'src/app/_models/Movie';
import { MovieService } from 'src/app/_services/movie.service';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css']
})
export class DetailsComponent {
  movieTitle:string = ''
  movie:Movie = {} as Movie
  constructor(private route:ActivatedRoute, private movieService:MovieService, private router:Router, private toastr:ToastrService){
  }
  ngOnInit() {
    this.route.paramMap.subscribe((params) => {
      if(params.get('title')!=null){
        var title = params.get('title');
        if(title) this.movieTitle = title
      }
      
    });
     this.movieService.getMovie(this.movieTitle).subscribe({
      next: (movie) => {
        if(movie) this.movie = movie
        else{
          this.router.navigateByUrl('movies')
        }
      },
      error: (err) => {
        this.router.navigateByUrl('movies')
        this.toastr.error('error: movie not found')
      }
     });
   
  }
}
