import { HttpClient } from '@angular/common/http';
import { Component, OnInit, TemplateRef } from '@angular/core';
import { Router } from '@angular/router';
import { Movie } from 'src/app/_models/Movie';
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
    this.movies = this.movies.filter(m => m.title != title)
    
  }
  GetMovies() {
    this.movieService.getMovies().subscribe({
      next: (movies) => (this.movies = movies),
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
}
