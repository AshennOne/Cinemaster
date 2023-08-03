import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ModalModule } from 'ngx-bootstrap/modal'; 
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './pages/home/home.component';
import { NavComponent } from './components/nav/nav.component';
import { MovieCardComponent } from './components/movie-card/movie-card.component';
import { FormInputComponent } from './components/form-input/form-input.component';
import { DetailsComponent } from './pages/details/details.component';
import { RegisterComponent } from './pages/register/register.component';
import { LoginComponent } from './pages/login/login.component';
import { MoviesComponent } from './pages/movies/movies.component';
import { ManageMoviesComponent } from './admin/manage-movies/manage-movies.component';
import { EditMovieComponent } from './admin/edit-movie/edit-movie.component';
import { AddMovieComponent } from './admin/add-movie/add-movie.component';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    NavComponent,
    MovieCardComponent,
    FormInputComponent,
    DetailsComponent,
    RegisterComponent,
    LoginComponent,
    MoviesComponent,
    ManageMoviesComponent,
    EditMovieComponent,
    AddMovieComponent,
    UploadImageComponent,
    FormComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    NgxDropzoneModule,
    ModalModule.forRoot(),
    CommonModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot({
      timeOut: 4000,
    positionClass: 'toast-bottom-right',
    preventDuplicates: true,

    }),
    BsDatepickerModule.forRoot(),
    BsDropdownModule.forRoot()
   
  ],
  providers: [{
    provide:HTTP_INTERCEPTORS,
    useClass:TokenInterceptor,
    multi:true
  }],
  bootstrap: [AppComponent],
})
export class AppModule {}import { NgxDropzoneModule } from 'ngx-dropzone';
import { UploadImageComponent } from './components/upload-image/upload-image.component';
import { FormComponent } from './components/form/form.component';
import { TokenInterceptor } from './_interceptors/token.interceptor';

