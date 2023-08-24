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
export class ManageMoviesComponent {
  modalRef: BsModalRef = {} as BsModalRef;
  selectedMovie: any;
  movies?: Movie[] = [];
  currentPage =  this.getCurrentPage();
  totalItems = this.movies?.length || 0;

  constructor(
    private movieService: MovieService,
    private router: Router,
    private modalService: BsModalService
  ) {}

  getCurrentPage(){
    var num = localStorage.getItem('pageNumber')
    
    if(num==null){
      return 1

    }else{
      
      return Number(num)
     
    }
  }
  openModal(template: TemplateRef<any>, movie: any) {
    this.selectedMovie = movie;
    this.modalRef = this.modalService.show(template, { class: 'modal-sm' });
  }
  confirmDelete(title: string) {
    this.movieService.deleteMovie(title);

    this.modalRef.hide();
    if (this.movies) this.movies = this.movies.filter((m) => m.title != title);
  }

  shortenDescription(description: string): string {
    return description.length > 50
      ? description.slice(0, 50) + '...'
      : description;
  }
  redirect(title: string) {
    this.router.navigateByUrl(title);
  }

  getMovies(event: any) {
  
    this.movies = event;
  }
  getTotalItems(event: any) {
    this.totalItems = event;
  }
  
}
