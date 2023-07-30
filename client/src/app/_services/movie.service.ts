import { Injectable } from '@angular/core';
import { HttpClient ,HttpClientModule} from '@angular/common/http';
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
  getMovie(title:string){
    return this.http.get<Movie>(this.baseUrl + 'movies/'+title);
  }
  addMovie(movie:Movie){
    console.log(movie)
    var x= this.http.post(this.baseUrl+"movies",movie);
    x.subscribe({
      next: ()=>{
        console.log("ok")
      }
    })
  }
}
