import { Component, Inject, OnInit  } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { Book } from '../models/book';

@Component({
  selector: 'edit-book',
  templateUrl: './edit-book.component.html',
  styleUrls: ['./edit-book.component.css']
})
export class EditBook implements OnInit  {
  public authorName: string;
  public book = new Book();
  public authorNameAutocompletes: Array<string> = [];
  public filteredAuthorNameAutocompletes: Array<string> = [];

  constructor(private route: ActivatedRoute,
              private router: Router,
              private http: HttpClient,
              @Inject('BASE_URL') private baseUrl: string)
    { }

  ngOnInit() {
    this.getBookDetails();
  }

  addAuthor() {
    this.book.authorNames.push(this.authorName)
    this.authorName = ''
  }

  removeAuthorName(authorName) {
    this.book.authorNames = this.book.authorNames.filter(name => name !== authorName)
  }

  setAuthor(authorName) {
    this.authorName = authorName;
    this.filteredAuthorNameAutocompletes = []; // clean
  }

  editBook() {
    this.http.put<any>(this.baseUrl + 'book', this.book).subscribe(response => {
      console.log(response)
      this.router.navigate([`/book-details/${this.route.snapshot.params.id}`])
    }, error => console.error(error));
  }

  getBookDetails() {
    this.http.get<any>(this.baseUrl + `book/${this.route.snapshot.params.id}`).subscribe(response => {
      this.book = response;
      console.log(response)
    }, error => console.error(error));
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