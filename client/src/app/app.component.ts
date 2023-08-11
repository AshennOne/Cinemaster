import {  AfterContentChecked, ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { ngxLoadingAnimationTypes } from 'ngx-loading';
import { LoadingService } from './_services/loading.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit, AfterContentChecked {
  title = 'client';
  isLoading = false;
  public ngxLoadingAnimationTypes = ngxLoadingAnimationTypes;
  public primaryColour = '#ffffff';
  public secondaryColour = '#ccc';
  constructor(public loadingService:LoadingService,private changeDetector: ChangeDetectorRef,){
    
  }
  ngAfterContentChecked(): void {
    this.changeDetector.detectChanges();
  }
  ngOnInit(): void {
    this.loadingService.loading$.subscribe({
      next: (bool)=> {
        this.isLoading = bool;
      }
    })
  }
}
