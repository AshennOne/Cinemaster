import { Component, EventEmitter, Input, OnChanges, OnInit, Output, SimpleChanges } from '@angular/core';
import { Movie } from 'src/app/_models/Movie';
import { MovieListService } from 'src/app/_services/movie-list.service';

@Component({
  selector: 'app-add-to-list',
  templateUrl: './add-to-list.component.html',
  styleUrls: ['./add-to-list.component.css']
})
export class AddToListComponent implements OnInit, OnChanges{
  @Input() movie?:Movie
  @Input() isMainPage = false
  @Input() isMyList = false;
  @Output() statusChange = new EventEmitter<boolean>()
  isLiked = false;
  constructor(private movieListService:MovieListService){}
  ngOnChanges(changes: SimpleChanges): void {
    if(changes['movie']){
      this.checkIsLiked();
    }
  }
  ngOnInit(): void {
    this.checkIsLiked();
  }
  checkIsLiked(){
    this.movieListService.getUserList().subscribe({
      next: (movies) => {
        movies.forEach(element => {
          if(element.id == this.movie?.id){
            this.isLiked = true;
          }
        });
      }
    });
  }
toggleMovie(){
  if(this.isLiked){
    this.removeMovie()
  }
  else{
    this.addMovie()
  }
}
  removeMovie(){
    if(!this.movie?.id) return;
    this.movieListService.deleteFromList(this.movie.id).subscribe({
      next: () => {
        this.isLiked = false;
        if(this.isMyList){
          this.statusChange.emit(true);
        }
      }
    })
  }
  
  addMovie(){
    if(!this.movie?.id) return;
    this.movieListService.addToList(this.movie.id).subscribe({
      next: () => {
        this.isLiked = true;
      }
    })
  }
}
