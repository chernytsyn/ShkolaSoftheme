import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { Book } from '../models/book.model';

import { FavoriteBooksService } from '../services/favorite-books.service';

@Component({
  selector: 'app-favorite-books',
  templateUrl: './favorite-books.component.html',
  styleUrls: ['./favorite-books.component.css']
})
export class FavoriteBooksComponent implements OnInit {

      favBooks$: Observable<Book[]>;
  
      constructor(private booksService: FavoriteBooksService) {
      }
  
      ngOnInit() {
          this.favBooks$ = this.booksService.getBooks();
      }
}
