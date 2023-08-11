import { DatePipe } from '@angular/common';
import { Component, OnInit, TemplateRef } from '@angular/core';
import { BsDatepickerConfig, BsLocaleService } from 'ngx-bootstrap/datepicker';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Movie } from 'src/app/_models/Movie';
import { MovieParams } from 'src/app/_models/MovieParams';
import { CommentService } from 'src/app/_services/comment.service';
import { MovieService } from 'src/app/_services/movie.service';

@Component({
  selector: 'app-movies',
  templateUrl: './movies.component.html',
  styleUrls: ['./movies.component.css'],
})
export class MoviesComponent implements OnInit {
  movies?: Movie[];
  currentPage = 1;
  totalItems = 0;
  movieParams: MovieParams = {
    SortOrder: 'TitleAsc',
    From: new Date(1900, 0, 1),
    To: new Date(),
    MinDuration: 1,
    MaxDuration: 999,
  };
  modalRef: BsModalRef = {} as BsModalRef;
  public bsConfig: Partial<BsDatepickerConfig>;

  constructor(
    private movieService: MovieService,
    private modalService: BsModalService,
    private bsLocaleService: BsLocaleService
  ) {
    this.bsLocaleService.use('en');
    this.bsConfig = {
      maxDate: new Date(),
      dateInputFormat: 'DD/MM/YYYY'
    };
  }
  ngOnInit(): void {
    this.GetMovies();
  }
  GetMovies() {
    this.movieService.getMovies(this.currentPage, this.movieParams).subscribe({
      next: (pagination) => {
        this.movies = pagination.movies;
        this.totalItems = pagination.totalItems;
      },
    });
  }
  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template, { class: 'modal-md' });
  }
  filterMovies() {
    this.GetMovies();
    this.modalRef.hide()
  }
  onChangePage() {
    this.GetMovies();
  }
}
