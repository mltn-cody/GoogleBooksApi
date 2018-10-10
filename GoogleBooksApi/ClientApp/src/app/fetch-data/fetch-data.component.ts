import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public books: IBook[];
  private http: HttpClient;
  private readonly baseUrl: string;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.http = http;
    this.baseUrl = baseUrl;
  }

  public search() {
    let querystring = encodeURIComponent((document.getElementById('search_field') as HTMLInputElement).value);
    this.http.get<IBook[]>(this.baseUrl + 'api/Books/Search?query=' + querystring).subscribe(result => {
      this.books = result;
    }, error => console.error(error));
  }
}

interface IBook {
  id: string,
  title: string,
  authors: string[],
  infoLink: string,
  description: string,
  publisher: string,
  pageCount: number,
  image: string;
}
