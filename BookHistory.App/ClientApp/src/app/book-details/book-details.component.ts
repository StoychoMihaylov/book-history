import { Component, Inject, OnInit  } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { BookDetailsModel } from '../models/book';
import { BookEditHistory } from '../models/book';

@Component({
  selector: 'book-details',
  templateUrl: './book-details.component.html',
  styleUrls: ['./book-details.component.css']
})
export class BookDetails implements OnInit  {
  public book = new BookDetailsModel();

  // Book ddit histories pagination
  public page = 0;
  public numberOfPages = 0;
  public changesPage: Array<BookEditHistory>;
  public filteredBookEditHistories : Array<BookEditHistory>;
  public activeFilter: string= "default";

  constructor(private route: ActivatedRoute, private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  ngOnInit() {
    this.getBookDetails();
  }

  paginationLeft() {
    if (this.page === 0) {
      return;
    }
    this.page -= 1;
    if (this.activeFilter === "default") {
      this.changesPage = this.book.bookEditHistories.slice(this.page * 5, (this.page + 1) * 5)
    } else {
      this.changesPage = this.filteredBookEditHistories.slice(this.page * 5, (this.page + 1) * 5);
    }
  }

  paginationRight() {
    if (this.page + 1 === this.numberOfPages) {
      return;
    }

    this.page += 1;
    if (this.activeFilter === "default") {
      this.changesPage = this.book.bookEditHistories.slice(this.page * 5, (this.page + 1) * 5)
    } else {
      this.changesPage = this.filteredBookEditHistories.slice(this.page * 5, (this.page + 1) * 5);
    }
  }

  setDefaultFilter() {
    this.page = 0;
    this.changesPage = this.book.bookEditHistories.slice(this.page * 5, (this.page + 1) * 5);
    this.numberOfPages = Math.ceil(this.book.bookEditHistories.length / 5);
    this.activeFilter = "default";
  }

  orderByDateASC() {
    this.page = 0;
    this.filteredBookEditHistories = this.book.bookEditHistories.sort((a,b) => 0 - (a.dateOfEdit > b.dateOfEdit ? -1 : 1));
    this.changesPage = this.filteredBookEditHistories.slice(this.page * 5, (this.page + 1) * 5);
    this.numberOfPages = Math.ceil(this.filteredBookEditHistories.length / 5);
    this.activeFilter = "filter";
  }

  orderByDateDESC() {
    this.page = 0;
    this.filteredBookEditHistories  = this.book.bookEditHistories.sort((a,b) => 0 - (a.dateOfEdit > b.dateOfEdit ? 1 : -1));
    this.changesPage = this.filteredBookEditHistories.slice(this.page * 5, (this.page + 1) * 5);
    this.numberOfPages = Math.ceil(this.filteredBookEditHistories.length / 5);
    this.activeFilter = "filter";
  }

  filterByTitleChange() {
    this.page = 0;
    this.filteredBookEditHistories = this.book.bookEditHistories.filter(x => x.titleChanges !== null);
    this.changesPage = this.filteredBookEditHistories.slice(this.page * 5, (this.page + 1) * 5);
    this.numberOfPages = Math.ceil(this.filteredBookEditHistories.length / 5);
    this.activeFilter = "filter";
  }

  filterByDescriptionChange() {
    this.page = 0;
    this.filteredBookEditHistories = this.book.bookEditHistories.filter(x => x.descriptionChanges !== null);
    this.changesPage = this.filteredBookEditHistories.slice(this.page * 5, (this.page + 1) * 5);
    this.numberOfPages = Math.ceil(this.filteredBookEditHistories.length / 5);
    this.activeFilter = "filter";
  }

  filterByAuthorChange() {
    this.page = 0;
    this.filteredBookEditHistories = this.book.bookEditHistories.filter(x => x.authorChanges !== null);
    this.changesPage = this.filteredBookEditHistories.slice(this.page * 5, (this.page + 1) * 5);
    this.numberOfPages = Math.ceil(this.filteredBookEditHistories.length / 5);
    this.activeFilter = "filter";
  }

  getBookDetails() {
    this.http.get<any>(this.baseUrl + `book/${this.route.snapshot.params.id}`).subscribe(response => {
      this.book = response;
      this.numberOfPages = Math.ceil(response.bookEditHistories.length / 5);
      this.changesPage = response.bookEditHistories.slice(0, 5);
    }, error => console.error(error));
  }
}