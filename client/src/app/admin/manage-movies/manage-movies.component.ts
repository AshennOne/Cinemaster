import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Movie } from 'src/app/_models/Movie';
import { MovieService } from 'src/app/_services/movie.service';

@Component({
  selector: 'app-manage-movies',
  templateUrl: './manage-movies.component.html',
  styleUrls: ['./manage-movies.component.css']
})
export class ManageMoviesComponent implements OnInit{

  movies: Movie[] = []
  constructor(private movieService:MovieService,private router: Router) {    
  }
  ngOnInit(): void {
    this.GetMovies();
  }

  GetMovies(){
    this.movieService.getMovies().subscribe({
      next: movies => this.movies = movies
      
    })
    
  }
  shortenDescription(description: string): string {
    return description.length > 50 ? description.slice(0, 50) + '...' : description;
  }
  redirect(title:string){
    this.router.navigateByUrl('admin/edit/'+title);
  }
}
