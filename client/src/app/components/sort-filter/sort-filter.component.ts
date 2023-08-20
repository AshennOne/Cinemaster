import { Component, EventEmitter, Input, OnChanges, OnInit, Output, SimpleChanges, TemplateRef } from '@angular/core';
import { Router } from '@angular/router';
import { BsDatepickerConfig, BsLocaleService } from 'ngx-bootstrap/datepicker';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Movie } from 'src/app/_models/Movie';
import { MovieParams } from 'src/app/_models/MovieParams';
import { MovieService } from 'src/app/_services/movie.service';

@Component({
  selector: 'app-sort-filter',
  templateUrl: './sort-filter.component.html',
  styleUrls: ['./sort-filter.component.css']
})
export class SortFilterComponent implements OnInit, OnChanges{
  selectedTitle = ''
  @Input() currentPage = 1
  @Input() url = ""
 @Output() totalItems = new EventEmitter<number>();
  movieParams: MovieParams = {
    SortOrder: 'TitleAsc',
    From: new Date(1900, 0, 1),
    To: new Date(),
    MinDuration: 1,
    MaxDuration: 999,
  };
  titles: string[] = []
  @Output() movies = new EventEmitter<Movie[]>();
  modalRef: BsModalRef = {} as BsModalRef;
  public bsConfig: Partial<BsDatepickerConfig>;
  constructor(private router:Router,private bsLocaleService: BsLocaleService, private modalService: BsModalService, private movieService: MovieService){
    this.bsLocaleService.use('en');
    this.bsConfig = {
      maxDate: new Date(),
      dateInputFormat: 'DD/MM/YYYY'
    };
  }
  ngOnChanges(changes: SimpleChanges): void {
    if(changes['currentPage']){
      this.GetMovies();
    }
  }
  ngOnInit(): void {
    this.GetMovies();
  }
  redirect(){
    this.router.navigateByUrl(this.url+this.selectedTitle)
  }
  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template, { class: 'modal-md' });
  }
 
  filterMovies() {
    this.GetMovies();
    this.modalRef.hide()
  }
  GetMovies() {
    this.movieService.getMovies(this.currentPage, this.movieParams).subscribe({
      next: (pagination) => {
        if(this.titles.length<1){
          pagination.movies.forEach(element => {
            this.titles.push( element.title)
           });
        }
        
        this.movies.emit( pagination.movies) ;
        this.totalItems.emit( pagination.totalItems);
      },
    });
  }
  onChangePage() {
    this.GetMovies();
  }
}
