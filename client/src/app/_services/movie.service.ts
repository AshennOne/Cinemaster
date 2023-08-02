import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Movie } from '../_models/Movie';

@Injectable({
  providedIn: 'root',
})
export class MovieService {
  baseUrl: string = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getMovies() {
    return this.http.get<Movie[]>(this.baseUrl + 'movies');
  }
  getMovie(title: string) {
    return this.http.get<Movie>(this.baseUrl + 'movies/' + title);
  }
  addMovie(movie: Movie) {
    return this.http.post(this.baseUrl + 'movies', movie).subscribe({
      
    });
    
  }
  editMovie(id:number,movie:Movie){
    return this.http.put(this.baseUrl + 'movies/'+ id, movie).subscribe({

    })
  }
  deleteMovie(title:string){
    return this.http.delete(this.baseUrl + 'movies/'+ title).subscribe({

    })
  }
}
