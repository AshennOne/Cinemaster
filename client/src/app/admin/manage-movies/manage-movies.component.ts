import { HttpClient } from '@angular/common/http';
import { Component, OnInit, TemplateRef } from '@angular/core';
import { Router } from '@angular/router';
import { Movie } from 'src/app/_models/Movie';
import { MovieParams } from 'src/app/_models/MovieParams';
import { MovieService } from 'src/app/_services/movie.service';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
@Component({
  selector: 'app-manage-movies',
  templateUrl: './manage-movies.component.html',
  styleUrls: ['./manage-movies.component.css'],
})
export class ManageMoviesComponent implements OnInit {
  modalRef: BsModalRef = {} as BsModalRef;
  selectedMovie: any;
  movies: Movie[] = [];
  currentPage = 1;
  totalItems = 0;
  
  movieParams: MovieParams = {
    SortOrder:"TitleAsc",
    From: new Date(1900,0,1),
    To: new Date(),
    MinDuration:1,
    MaxDuration:999
  }
  constructor(
    private movieService: MovieService,
    private router: Router,
    private modalService: BsModalService
  ) {}
  ngOnInit(): void {
    this.GetMovies();
  }

  openModal(template: TemplateRef<any>, movie: any) {
    this.selectedMovie = movie;
    this.modalRef = this.modalService.show(template, { class: 'modal-sm' });
  }
  confirmDelete(title: string) {
    this.movieService.deleteMovie(title);

    this.modalRef.hide();
    this.movies = this.movies.filter((m) => m.title != title);
  }
  GetMovies() {
    if(this.movieService.getParamsFromCache() ==null) return;
    this.movieService.getMovies(this.currentPage).subscribe({
      next: (pagination) => {
        this.movies = pagination.movies,
        this.totalItems = pagination.totalItems
      },
    });
  }
  shortenDescription(description: string): string {
    return description.length > 50
      ? description.slice(0, 50) + '...'
      : description;
  }
  redirect(title: string) {
    this.router.navigateByUrl(title);
  }
  onChangePage(){
        
    this.GetMovies()
  }
 

  getMovies(event:any){
    this.movies = event
    
  }
  getTotalItems(event:any){
    this.totalItems = event
  }
}
