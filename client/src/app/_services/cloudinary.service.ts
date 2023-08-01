import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class CloudinaryService {
  baseUrl = environment.apiUrl;
  constructor(private http: HttpClient) {}
  uploadImage(values:any):Observable<any>{
    let data = values
    return this.http.post('https://api.cloudinary.com/v1_1/dwy4hhhjr/image/upload',data);
  }
}
