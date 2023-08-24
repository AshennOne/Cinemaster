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
import { AuthGuard } from './_guards/auth.guard';
import { AntiAuthGuard } from './_guards/anti-auth.guard';
import { AdminGuard } from './_guards/admin.guard';
import { MyInteractionsComponent } from './pages/my-interactions/my-interactions.component';
import { RankingComponent } from './pages/ranking/ranking.component';

const routes: Routes = [
  { path: '', component: HomeComponent,canActivate:[AntiAuthGuard] },
  { path: 'movies', component: MoviesComponent, canActivate:[AuthGuard] },
  { path: 'movies/:title', component: DetailsComponent, canActivate:[AuthGuard] },
  { path: 'login', component: LoginComponent ,canActivate:[AntiAuthGuard]},
  { path: 'interactions', component: MyInteractionsComponent, canActivate:[AuthGuard] },
  { path: 'ranking', component: RankingComponent, canActivate:[AuthGuard] },
  { path: 'register', component: RegisterComponent ,canActivate:[AntiAuthGuard]},
  { path: 'admin/dashboard', component: ManageMoviesComponent, canActivate:[AdminGuard] },
  { path: 'admin/edit/:title', component: EditMovieComponent, canActivate:[AdminGuard] },
  { path: 'admin/add', component: AddMovieComponent, canActivate:[AdminGuard] },
  { path: '**', component: HomeComponent,canActivate:[AntiAuthGuard] }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
