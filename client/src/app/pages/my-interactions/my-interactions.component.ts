import { Component, ViewEncapsulation } from '@angular/core';
import { TabDirective } from 'ngx-bootstrap/tabs';

@Component({
  selector: 'app-my-interactions',
  templateUrl: './my-interactions.component.html',
  styleUrls: ['./my-interactions.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class MyInteractionsComponent{

  public activeTab: string = this.getTab()

changeTab(event:TabDirective) {
  if(event.heading){
    localStorage.setItem('tab',event.heading)
    this.activeTab = event.heading;
  }
 
}
 getTab():string{
  var tab = localStorage.getItem('tab')
  if(!tab){
    tab = "My liked movies"
    localStorage.setItem('tab',tab)
    
  }
  
  return tab;
 }
 
  
}
