import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Movie } from '../_models/Movie';
import { MoviePagination } from '../_models/MoviePagination';
import { MovieParams } from '../_models/MovieParams';
import { map, of, tap } from 'rxjs';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root',
})
export class MovieService {
  baseUrl: string = environment.apiUrl;

  constructor(private http: HttpClient,private router:Router) {}

  getMovies(currentPage: number, movieParams: MovieParams) {
    
    return this.http.post<MoviePagination>(
      this.baseUrl + 'movies/' + currentPage,
      movieParams
    ).pipe(
      map((movies)=>{
        movies.movies.forEach(element => {
          if(!this.getMovieFromCache(element.title))
            this.setMovieToCache(element)
        });
       
        return movies;
      })
    )
  }
  getMovie(title: string) {
  var cachedMovie = this.getMovieFromCache(title)
  if(cachedMovie === "null" ||cachedMovie === null){
    
    return this.http.get<Movie>(this.baseUrl + 'movies/' + title).pipe(
      map((movie)=>{
        this.setMovieToCache(movie);
        return movie;
      })
    );
  }
   else{
    var movie:Movie = JSON.parse(cachedMovie)
    return of(movie);
   }
  }
  addMovie(movie: Movie) {
    return this.http.post(this.baseUrl + 'movies', movie).subscribe({});
  }
  editMovie(id: number, movie: Movie) {
    return this.http.put(this.baseUrl + 'movies/' + id, movie).subscribe({});
  }
  deleteMovie(title: string) {
    return this.http.delete(this.baseUrl + 'movies/' + title).subscribe({});
  }
  getMovieFromCache(title:string){
  return  localStorage.getItem(title)
  }
  setMovieToCache(movie:Movie){
  
   
      localStorage.setItem(movie.title, JSON.stringify(movie))
   
  }
}
