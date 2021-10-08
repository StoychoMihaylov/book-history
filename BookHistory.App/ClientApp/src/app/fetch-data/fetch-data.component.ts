import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public bookId: string;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.post<any>(baseUrl + 'book', { title: "Test", description: "test test test", authorNames: ["John", "Harris", "Ho"] }).subscribe(response => {
      this.bookId = response;
      console.log(response)
    }, error => console.error(error));
  }
}
