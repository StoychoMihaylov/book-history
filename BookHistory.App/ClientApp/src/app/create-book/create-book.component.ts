import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Book } from '../models/book';

@Component({
  selector: 'create-book',
  templateUrl: './create-book.component.html',
  styleUrls: ['./create-book.component.css']
})
export class CreateBook {
  private http: HttpClient;
  private baseUrl: string;

  public bookId: string;
  public authorName: string;
  public book = new Book();
  public authorNameAutocompletes: Array<string> = [];
  public filteredAuthorNameAutocompletes: Array<string> = [];

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
    }, error => console.error(error));
  }

  setAuthor(authorName) {
    this.authorName = authorName;
    this.filteredAuthorNameAutocompletes = []; // clean
  }

  getAuthorNameAutocompletes() {
    this.authorNameAutocompletes = []; // clean
    this.http.get<any>(this.baseUrl + 'authors').subscribe(response => {
      response.forEach(author => {
        this.authorNameAutocompletes.push(author.name);
      });
    }, error => console.error(error));
  }

  filterAuthorAutocompletes(authorName: string) {
    if (authorName !== "") {
      this.filteredAuthorNameAutocompletes = this.authorNameAutocompletes
      .filter(x => x.toLocaleLowerCase().startsWith(authorName.toLocaleLowerCase()));
    } else {
      this.filteredAuthorNameAutocompletes = []; // clean
    }
  }
}
