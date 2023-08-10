import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LoadingService {

  constructor() { }
  private loadingCount = 0;
  loading$ = new Subject<boolean>();

  showLoading(): void {
    this.loadingCount++;
    this.loading$.next(true);
  }

  hideLoading(): void {
    this.loadingCount--;
    if (this.loadingCount <= 0) {
      this.loadingCount = 0;
      this.loading$.next(false);
    }
  }
}
