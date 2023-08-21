import {
  Component,
  EventEmitter,
  Input,
  OnChanges,
  OnInit,
  Output,
  SimpleChanges,
} from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Comment } from 'src/app/_models/Comment';
import { Movie } from 'src/app/_models/Movie';
import { CommentService } from 'src/app/_services/comment.service';
import { MovieService } from 'src/app/_services/movie.service';

@Component({
  selector: 'app-all-comments',
  templateUrl: './all-comments.component.html',
  styleUrls: ['./all-comments.component.css'],
})
export class AllCommentsComponent implements OnChanges, OnInit {
  @Input() movie?: Movie;
  @Output() updateComment = new EventEmitter<boolean>();
  content = '';
  comments: Comment[] = [];
  constructor(
    private commentService: CommentService,
    private toastr: ToastrService,
    
  ) {}
  ngOnInit(): void {
    this.getComments();
  }

  ngOnChanges(changes: SimpleChanges): void {
    if (this.movie && changes['movie']) {
      this.getComments();
    }
  }
  getComments() {
    if (!this.movie) return;
    this.comments = this.movie.comments
  }
  updateLocalStorage(){
    this.updateComment.emit(true);
  }
  addComment() {
    if (this.content == '' || !this.movie?.id) {
      this.toastr.error('unable to add empty comment');
    } else {
      this.commentService.addComment(this.movie.id, this.content).subscribe({
        next: () => {
          this.updateLocalStorage();
         
          this.getComments();
          this.content = '';
          this.toastr.success('successfully added new comment!');
        },
        error: (err) => {
          console.log(err);
        },
      });
    }
  }
  deleteComment(event: any) {
    this.commentService.deleteComment(event).subscribe({
      next: () => {
          this.updateLocalStorage();
      
        this.getComments();
        this.toastr.success('Comment has been deleted successfuly');
      },
      error: (err) => {
        this.toastr.error('error occured while deleting, try again later');
      },
    });
  }
}
