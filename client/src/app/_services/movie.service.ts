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
}
