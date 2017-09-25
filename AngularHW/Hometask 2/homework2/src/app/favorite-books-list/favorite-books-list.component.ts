import { Component, OnInit } from '@angular/core';
import { Ibook } from '../ibook';
import { FavoriteBooksService } from '../favorite-books.service';

import { Observable } from 'rxjs/Observable';

@Component({
  selector: 'app-favorite-books-list',
  templateUrl: './favorite-books-list.component.html',
  styleUrls: ['./favorite-books-list.component.css']
})
export class FavoriteBooksListComponent implements OnInit {

  constructor(private favoriteBooksService: FavoriteBooksService) { }

  books$: Observable<Ibook[]>;

  ngOnInit() {
    this.books$ = this.favoriteBooksService.getFavoriteBooks();
  }

}
