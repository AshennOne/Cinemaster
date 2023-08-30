import { getCurrencySymbol } from '@angular/common';
import {
  Component,
  EventEmitter,
  Input,
  OnChanges,
  OnInit,
  Output,
  SimpleChanges,
  TemplateRef,
} from '@angular/core';
import { Router } from '@angular/router';
import { BsDatepickerConfig, BsLocaleService } from 'ngx-bootstrap/datepicker';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Movie } from 'src/app/_models/Movie';
import { MovieParams } from 'src/app/_models/MovieParams';
import { MovieService } from 'src/app/_services/movie.service';

@Component({
  selector: 'app-sort-filter',
  templateUrl: './sort-filter.component.html',
  styleUrls: ['./sort-filter.component.css'],
})
export class SortFilterComponent implements OnInit, OnChanges {
  selectedTitle = '';
  @Input() currentPage? :number
  @Input() url = '';
  @Output() totalItems = new EventEmitter<number>();
  movieParams: MovieParams = this.DefaultParams();
  titles: string[] = [];
  @Output() movies = new EventEmitter<Movie[]>();
  modalRef: BsModalRef = {} as BsModalRef;
  public bsConfig: Partial<BsDatepickerConfig>;
  constructor(
    private router: Router,
    private bsLocaleService: BsLocaleService,
    private modalService: BsModalService,
    private movieService: MovieService
  ) {
    this.bsLocaleService.use('en');
    this.bsConfig = {
      maxDate: new Date(),
      dateInputFormat: 'DD/MM/YYYY',
    };
  }
  resetParams() {
    this.movieParams = this.DefaultParams();
    this.movieService.setParamsToCache(this.movieParams);

    this.modalRef.hide();
    this.GetMovies();
  }
  DefaultParams() {
    return {
      SortOrder: 'TitleAsc',
      From: (new Date(1900, 0, 1)),
      To: new Date(),
      MinDuration: 1,
      MaxDuration: 999,
    } as MovieParams;
  }
  ngOnChanges(changes: SimpleChanges): void {
    if (changes['currentPage'] && this.currentPage) {
      this.movieService.setPageNumber(this.currentPage)
   
      this.GetMovies();
    }
  }
  
  ngOnInit(): void {
  
    var params = this.movieService.getParamsFromCache();
    if (params == null) {
      this.movieService.setParamsToCache(this.movieParams);
    } else {
      this.setMovieParams(params);
    }
    this.GetMovies();
   this.getTitles();
  }

  setMovieParams(params: string) {
    var parsedParams = JSON.parse(params);
    this.movieParams.SortOrder = parsedParams.SortOrder;
    this.movieParams.From = new Date(parsedParams.From.substring(0, 10));
    this.movieParams.To = new Date(parsedParams.To.substring(0, 10));
    this.movieParams.MinDuration = parsedParams.MinDuration;
    this.movieParams.MaxDuration = parsedParams.MaxDuration;
  }

  redirect() {
    this.router.navigateByUrl(this.url + this.selectedTitle);
  }
  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template, { class: 'modal-md' });
  }

  filterMovies() {
   
    this.movieService.setParamsToCache(this.movieParams);
    this.GetMovies();
    this.modalRef.hide();
  }
  GetMovies() {
    if(!this.currentPage) return
  
    if (this.movieService.getParamsFromCache() == null) return;
    this.movieService.getMovies(this.currentPage).subscribe({
      next: (pagination) => {
        

        this.movies.emit(pagination.movies);
        this.totalItems.emit(pagination.totalItems);
      },
    });
  }
 getTitles(){
  this.movieService.getTitles().subscribe({
    next:(titles) => {
      this.titles = titles
    }
  })
 }
}
