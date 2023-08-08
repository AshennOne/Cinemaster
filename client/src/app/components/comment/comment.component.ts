import { Component, EventEmitter, Input, OnChanges, Output, SimpleChanges, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Comment } from 'src/app/_models/Comment';
import { User } from 'src/app/_models/User';
import { AccountService } from 'src/app/_services/account.service';
import { UserService } from 'src/app/_services/user.service';

@Component({
  selector: 'app-comment',
  templateUrl: './comment.component.html',
  styleUrls: ['./comment.component.css'],
})
export class CommentComponent implements OnChanges {
  @Input() comment?: Comment;
  @Output() commentToDelete = new EventEmitter<number>();
  userName = '';
  belongToCurrent = false;
  modalRef: BsModalRef = {} as BsModalRef;
  constructor(private userService: UserService, private accountService:AccountService, private modalService:BsModalService) {}
  ngOnChanges(changes: SimpleChanges): void {
    if (changes['comment']) {
      this.getUser();
    }
  }

  getUser() {
    if (this.comment?.userId != null) {
      this.userService.getUserById(this.comment.userId).subscribe({
        next: (user) => {
          this.userName = user.userName;
          var token = localStorage.getItem('token')
          if(token){
            var currentUserUsername =  this.accountService.getTokenClaims(token).unique_name
            if(currentUserUsername == this.userName){
              this.belongToCurrent =true
            }
          }
          
          
        },
      });
    }
  }

  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template, { class: 'modal-sm' });
  }
  confirmDelete() {
    if(!this.comment?.id)return;
    this.commentToDelete.emit(this.comment.id)
   
    this.modalRef.hide();
    
}
}