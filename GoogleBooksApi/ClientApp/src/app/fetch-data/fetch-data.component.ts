import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public books: IBook[];
  public errorMsg: string;
  public showLoadingGif: boolean;
  private http: HttpClient;
  private readonly baseUrl: string;
  private currentPage: number;
  private querystring: string;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.http = http;
    this.showLoadingGif = false;
    this.baseUrl = baseUrl;
    this.currentPage = 0
  }

  public search() {
    this.querystring = encodeURIComponent((document.getElementById('search_field') as HTMLInputElement).value);
    this.showLoadingGif = true;
    this.http.get<IBook[]>(this.baseUrl + 'api/Books/Search?query=' + this.querystring).subscribe(result => {
      this.books = result;
      this.showLoadingGif = false;
    }, error => {
      this.errorMsg = error;
      console.error(error);
    });
  }

  public next() {
    let nextPage = (this.currentPage + 10);
    this.showLoadingGif = true;
    this.http.get<IBook[]>(this.baseUrl + 'api/Books/Search?query=' + this.querystring + '&offset=' + nextPage).subscribe(result => {
      this.books = result;
      this.showLoadingGif = false;
      this.currentPage = nextPage;
    }, error => {
      this.errorMsg = error;
      console.error(error);
    });
  }

  public prev() {
    let prevPage = (this.currentPage > 0 ? this.currentPage - 10 : 0);
    if (prevPage === 0) return;
    this.showLoadingGif = true;
    this.http.get<IBook[]>(this.baseUrl + 'api/Books/Search?query=' + this.querystring + '&offset=' + prevPage).subscribe(result => {
      this.books = result;
      this.showLoadingGif = false;
      this.currentPage = prevPage;
    }, error => {
      this.errorMsg = error;
      console.error(error);
    });
  }


  public eventHandler(keycode: number) {
    if (keycode === 13)
      this.search();
    return;
  }
}

export interface IBook {
  id: string,
  title: string,
  authors: string[],
  infoLink: string,
  description: string,
  publisher: string,
  pageCount: number,
  image: string;
}
