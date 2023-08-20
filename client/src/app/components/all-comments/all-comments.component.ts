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

@Component({
  selector: 'app-all-comments',
  templateUrl: './all-comments.component.html',
  styleUrls: ['./all-comments.component.css'],
})
export class AllCommentsComponent implements OnChanges, OnInit {
  @Input() movie?: Movie;
  content = '';
  comments: Comment[] = [];
  constructor(
    private commentService: CommentService,
    private toastr: ToastrService
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
    if (!this.movie?.title) return;
    this.commentService.getMovieComments(this.movie.title).subscribe({
      next: (comments) => {
        if (comments) {
          this.comments = comments;
        }
      },
    });
  }
  addComment() {
    if (this.content == '' || !this.movie?.id) {
      this.toastr.error('unable to add empty comment');
    } else {
      this.commentService.addComment(this.movie.id, this.content).subscribe({
        next: () => {
          this.toastr.success('successfully added new comment!');
          this.getComments();
          this.content = '';
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
        this.toastr.success('Comment has been deleted successfuly');
        this.getComments();
      },
      error: (err) => {
        this.toastr.error('error occured while deleting, try again later');
      },
    });
  }
}
