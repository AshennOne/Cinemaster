import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Comment } from '../_models/Comment';
import { BehaviorSubject, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CommentService {
baseUrl = environment.apiUrl;





  constructor(private http:HttpClient) { }

  
  getUserComments(){
    return this.http.get<Comment[]>(this.baseUrl + 'comments/user');
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
