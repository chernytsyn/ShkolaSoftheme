import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FavoriteBooksListComponent } from './favorite-books-list.component';

describe('FavoriteBooksListComponent', () => {
  let component: FavoriteBooksListComponent;
  let fixture: ComponentFixture<FavoriteBooksListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FavoriteBooksListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FavoriteBooksListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
