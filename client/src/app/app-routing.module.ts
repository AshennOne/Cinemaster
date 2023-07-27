import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';
import { MoviesComponent } from './pages/movies/movies.component';
import { RegisterComponent } from './pages/register/register.component';
import { LoginComponent } from './pages/login/login.component';
import { DetailsComponent } from './pages/details/details.component';
import { AddMovieComponent } from './admin/add-movie/add-movie.component';
import { EditMovieComponent } from './admin/edit-movie/edit-movie.component';
import { ManageMoviesComponent } from './admin/manage-movies/manage-movies.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'movies', component: MoviesComponent },
  { path: 'movies/:title', component: DetailsComponent },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'admin/dashboard', component: ManageMoviesComponent },
  { path: 'admin/edit/:title', component: EditMovieComponent },
  { path: 'admin/add', component: AddMovieComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
