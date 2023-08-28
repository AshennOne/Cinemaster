import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Rating } from '../_models/Rating';
import { UserRatings } from '../_models/UserRatings';

@Injectable({
  providedIn: 'root',
})
export class RatingService {
  baseUrl = environment.apiUrl;
  constructor(private http: HttpClient) {}

 
  getAllUserRatings(page:number) {
    return this.http.get<UserRatings>(this.baseUrl + 'ratings/user/'+page);
  }
  addRating(id: number, grade: number) {
    var bodyContent = {grade}
    return this.http.post(
      this.baseUrl + 'ratings/' + id,
      bodyContent
    );
  }
  editRating(id: number, grade: number) {
    var bodyContent = {grade}
    return this.http.put(
      this.baseUrl + 'ratings/' + id,
      bodyContent
    );
  }
}
