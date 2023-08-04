import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, catchError, tap, throwError } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class CloudinaryService {
  baseUrl = environment.apiUrl;
  constructor(private http: HttpClient) {}
  uploadImage(imageFile: File) {
    if(!imageFile) console.log("No photo found")
    const formData = new FormData();
    formData.append('file', imageFile);
      return this.http.post<any>(this.baseUrl+'cloudinary',formData).pipe(
        
        catchError((err: any) => {
          console.error('Interceptor Error:', err);
          
          return throwError(() => new Error('Undefined error occurred'));
        })
      );
  
}
}