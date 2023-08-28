import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { MovieList } from '../_models/MovieList';
import { UserList } from '../_models/UserList';
import { Movie } from '../_models/Movie';

@Injectable({
  providedIn: 'root'
})
export class MovieListService {
baseUrl = environment.apiUrl
  constructor(private http:HttpClient) { }
  getUserList(){
    return this.http.get<Movie[]>(this.baseUrl + 'usermovies');
  }
  getPaginatedUserList(page:number){
    return this.http.get<UserList>(this.baseUrl + 'usermovies/'+page);
  }
  addToList(movieId:number){
    return this.http.post(this.baseUrl + 'usermovies/'+movieId,{});
  }
  deleteFromList(movieId:number){
    return this.http.delete(this.baseUrl + 'usermovies/'+movieId);
  }
}
