import { Component, Input } from '@angular/core';
import { Router } from '@angular/router';
import { Movie } from 'src/app/_models/Movie';

@Component({
  selector: 'app-raking-element',
  templateUrl: './raking-element.component.html',
  styleUrls: ['./raking-element.component.css']
})
export class RakingElementComponent {
@Input() movie?:Movie
constructor(private router :Router){}
redirect(){
  this.router.navigateByUrl('movies/' + this.movie?.title);
}
}
