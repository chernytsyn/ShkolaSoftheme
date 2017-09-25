import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { Ibook } from  '../app/ibook'

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';

@Injectable()
export class FavoriteBooksService {

  constructor(private http: Http) { }

  getFavoriteBooks():Observable<Ibook[]> {
    return this.http.get('http://localhost:3000/books')
                    .map((response: any) => response.json());
  }
}
