import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {Http, HttpModule} from '@angular/http'
import { FavoriteBooksService } from '../app/favorite-books.service'

import { AppComponent } from './app.component';
import { FavoriteBooksListComponent } from './favorite-books-list/favorite-books-list.component';

@NgModule({
  declarations: [
    AppComponent,
    FavoriteBooksListComponent
  ],
  imports: [
    BrowserModule,
    HttpModule,
    Http
  ],
  providers: [FavoriteBooksService],
  bootstrap: [AppComponent]
})
export class AppModule { }
