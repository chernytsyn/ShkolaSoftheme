import { TestBed, inject } from '@angular/core/testing';

import { FavoriteBooksService } from './favorite-books.service';

describe('FavoriteBooksService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [FavoriteBooksService]
    });
  });

  it('should be created', inject([FavoriteBooksService], (service: FavoriteBooksService) => {
    expect(service).toBeTruthy();
  }));
});
