import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

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
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';

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
    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
