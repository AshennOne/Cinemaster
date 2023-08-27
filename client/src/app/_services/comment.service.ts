import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Comment } from '../_models/Comment';
import { BehaviorSubject, Observable } from 'rxjs';
import { UserComments } from '../_models/UserComments';

@Injectable({
  providedIn: 'root'
})
export class CommentService {
baseUrl = environment.apiUrl;





  constructor(private http:HttpClient) { }

  
  getUserComments(currentPage:number){
    return this.http.get<UserComments>(this.baseUrl + 'comments/user/'+currentPage);
  }
  addComment(id: number, content:string){
   var bodyContent = {content}
    return this.http.post(this.baseUrl + 'comments/'+id, bodyContent)
  }
  editComment(id: number, content:string){
    var bodyContent = {content}
    return this.http.put(this.baseUrl + 'comments/'+id, bodyContent)
  }
  deleteComment(id:number){
    return this.http.delete(this.baseUrl+ 'comments/' + id);
  }
  
}
