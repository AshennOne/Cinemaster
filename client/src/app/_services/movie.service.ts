import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Movie } from '../_models/Movie';
import { MoviePagination } from '../_models/MoviePagination';
import { MovieParams } from '../_models/MovieParams';
import { map, of } from 'rxjs';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root',
})
export class MovieService {
  baseUrl: string = environment.apiUrl;

  constructor(private http: HttpClient,private router:Router) {}

  getMovies(currentPage: number) {
   var params = this.getParamsFromCache()
 
    return this.http.post<MoviePagination>(
      this.baseUrl + 'movies/' + currentPage,
      JSON.parse(params!)
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
  updateMovie(title:string){
    return this.http.get<Movie>(this.baseUrl + 'movies/' + title)
  }
  getTitles(){
    return this.http.get<string[]>(this.baseUrl + 'movies/titles')
  }
  getMoviesRanking(currentPage:number){
   var params = {
      SortOrder: 'RatingDesc',
      From: (new Date(1900, 0, 1)),
      To: new Date(),
      MinDuration: 1,
      MaxDuration: 999,
    } as MovieParams;
    return this.http.post<MoviePagination>(this.baseUrl + 'movies/' + currentPage,
    params)
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
  getMovieById(id: number) {
    
      return this.http.get<Movie>(this.baseUrl + 'movies/id/' + id)
   
    }
  addMovie(movie: Movie) {
    return this.http.post<Movie>(this.baseUrl + 'movies', movie).subscribe({
      next:(movie) => {
        
        this.setMovieToCache(movie)
        
      }
    });
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
  getParamsFromCache(){
   return localStorage.getItem('movieParams')
  }
  setParamsToCache(movieParams:MovieParams){
    localStorage.setItem('movieParams',JSON.stringify(movieParams))
  }
  getPageNumber(){
   return localStorage.getItem('pageNumber')
  }
  setPageNumber(number:number){
    localStorage.setItem('pageNumber',number.toString())
  }
}
