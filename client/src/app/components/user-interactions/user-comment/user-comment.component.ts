import { Component, EventEmitter, Input, OnChanges, Output, SimpleChanges, TemplateRef } from '@angular/core';
import { Router } from '@angular/router';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Comment } from 'src/app/_models/Comment';
import { Movie } from 'src/app/_models/Movie';
import { CommentService } from 'src/app/_services/comment.service';
import { MovieService } from 'src/app/_services/movie.service';

@Component({
  selector: 'app-user-comment',
  templateUrl: './user-comment.component.html',
  styleUrls: ['./user-comment.component.css'],
})
export class UserCommentComponent implements OnChanges {
  @Input() comment?: Comment;
  @Output() commentToDelete = new EventEmitter<number>();
  movie?: Movie;
  isHovering: boolean = false;
  modalRef: BsModalRef = {} as BsModalRef;
  constructor(private movieService: MovieService,private modalService:BsModalService, private router:Router) {}
  ngOnChanges(changes: SimpleChanges): void {
    if (changes['comment'] && this.comment?.id && !this.movie) {
    
        this.movieService.getMovieById(this.comment.movieId).subscribe({
          next: (movie) => {
            this.movie = movie;
          },
        });
    }
  }
  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template, { class: 'modal-sm' });
  }
  shortenContent(): string {
    if(!this.comment) return""
    return this.comment.content.length > 50
      ? this.comment.content.slice(0, 50) + '...'
      : this.comment.content;
  }
  redirect(){
    this.router.navigateByUrl('movies/' + this.movie?.title);
  }
  confirmDelete() {
    if(!this.comment?.id)return;
   
    this.commentToDelete.emit(this.comment.id)
    this.modalRef.hide();
    
}
}
