import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Book } from '../models/book';

@Component({
  selector: 'create-book',
  templateUrl: './create-book.component.html'
})
export class CreateBook {
  private http: HttpClient;
  private baseUrl: string;
  
  public bookId: string;
  public authorName: string;
  public book = new Book();

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.http = http;
    this.baseUrl = baseUrl;
  }

  addAuthor() {
    this.book.authorNames.push(this.authorName)
    this.authorName = ''
  }

  createBook() {
    this.http.post<any>(this.baseUrl + 'book', this.book).subscribe(response => {
      this.bookId = response;
      console.log(response)
    }, error => console.error(error));
  }
}
