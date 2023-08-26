import { Component } from '@angular/core';
import { Comment } from 'src/app/_models/Comment';
import { CommentService } from 'src/app/_services/comment.service';

@Component({
  selector: 'app-user-comments-tab',
  templateUrl: './user-comments-tab.component.html',
  styleUrls: ['./user-comments-tab.component.css']
})
export class UserCommentsTabComponent {
  comments: Comment[] = []
  constructor(private commentService:CommentService) {
    
    this.commentService.getUserComments().subscribe({
      next:(comments) =>{
        this.comments = comments
      }
    })
  }
}
