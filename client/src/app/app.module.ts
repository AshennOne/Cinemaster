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
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RatingConfig } from 'ngx-bootstrap/rating';
import { UploadImageComponent } from './components/upload-image/upload-image.component';
import { FormComponent } from './components/form/form.component';
import { TokenInterceptor } from './_interceptors/token.interceptor';
import { CommentComponent } from './components/comment/comment.component';
import { AllCommentsComponent } from './components/all-comments/all-comments.component';
import { RatingComponent } from './components/rating/rating.component';
import { AddToListComponent } from './components/add-to-list/add-to-list.component';
import { LoadingService } from './_services/loading.service';
import { SortFilterComponent } from './components/sort-filter/sort-filter.component';
import { MyInteractionsComponent } from './pages/my-interactions/my-interactions.component';
import { RankingComponent } from './pages/ranking/ranking.component';
import { UserCommentComponent } from './components/user-interactions/user-comment/user-comment.component';
import { UserRatingComponent } from './components/user-interactions/user-rating/user-rating.component';
import { UserListElementComponent } from './components/user-interactions/user-list-element/user-list-element.component';
import { SharedModule } from './_modules/shared.module';
import { UserCommentsTabComponent } from './components/user-comments-tab/user-comments-tab.component';
import { UserRatingsTabComponent } from './components/user-ratings-tab/user-ratings-tab.component';
import { UserListTabComponent } from './components/user-list-tab/user-list-tab.component';
import { RakingElementComponent } from './components/raking-element/raking-element.component';

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
    CommentComponent,
    AllCommentsComponent,
    RatingComponent,
    AddToListComponent,
    SortFilterComponent,
    MyInteractionsComponent,
    RankingComponent,
    UserCommentComponent,
    UserRatingComponent,
    UserListElementComponent,
    UserCommentsTabComponent,
    UserRatingsTabComponent,
    UserListTabComponent,
    RakingElementComponent,
 
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    
    CommonModule,
    BrowserAnimationsModule,
    SharedModule,
   
    FormsModule,
    
    
  ],
  providers: [LoadingService,{
    provide:HTTP_INTERCEPTORS,
    useClass:TokenInterceptor,
    multi:true
  },RatingConfig],
  bootstrap: [AppComponent],
})
export class AppModule {}



