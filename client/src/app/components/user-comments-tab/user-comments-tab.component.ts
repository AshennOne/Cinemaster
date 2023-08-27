import { Component } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Comment } from 'src/app/_models/Comment';
import { CommentService } from 'src/app/_services/comment.service';

@Component({
  selector: 'app-user-comments-tab',
  templateUrl: './user-comments-tab.component.html',
  styleUrls: ['./user-comments-tab.component.css']
})
export class UserCommentsTabComponent {
  comments: Comment[] = []
  loaded = false
  currentPage = 1
  totalItems = 0
  constructor(private commentService:CommentService, private toastr:ToastrService) {
    
    this.getComments()
    
  }
  getComments(){
    this.commentService.getUserComments(this.currentPage).subscribe({
      next:(comments) =>{
        this.comments = comments.comments
        this.totalItems = comments.totalItems
        this.loaded=  true
      }
    })
  }
  deleteComment(event: any) {
    this.commentService.deleteComment(event).subscribe({
      next: () => {
      
        this.getComments();
        this.toastr.success('Comment has been deleted successfuly');
      },
      error: () => {
        this.toastr.error('error occured while deleting, try again later');
      },
    });
  }
}
