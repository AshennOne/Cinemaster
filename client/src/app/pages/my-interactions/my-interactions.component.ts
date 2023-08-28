import { Component, ViewEncapsulation } from '@angular/core';
import { TabDirective } from 'ngx-bootstrap/tabs';

@Component({
  selector: 'app-my-interactions',
  templateUrl: './my-interactions.component.html',
  styleUrls: ['./my-interactions.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class MyInteractionsComponent{

  public activeTab?: string = "My liked movies"; 

changeTab(event:TabDirective) {
   this.activeTab = event.heading;
}
 
  
}
