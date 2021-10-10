import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  public books: Books;

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
    this.http = http;
    this.baseUrl = baseUrl;
  }

  ngOnInit() {
    this.http.get<any>(this.baseUrl + 'books').subscribe(response => {
     this.books = response;
    }, error => console.error(error));
  }
}

interface Books {
  id: string,
  title: string,
  authors: Array<string>
}
