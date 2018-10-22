import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable, Inject } from '@angular/core'
import { Observable } from 'rxjs/Observable';
import Fetchdatacomponent = require("./fetch-data.component");
import IBook = Fetchdatacomponent.IBook;

export class Page<T> {
  count: number;
  next: string;
  previous: string;
  results: Array<T>;
}

export function queryPaginated<T>(http: HttpClient, baseUrl: string, urlOrFilter?: string | object):
  Observable<Page<T>> {
  let params = new HttpParams();
  let url = baseUrl;

  if (typeof urlOrFilter === 'string') {
    url = urlOrFilter;
  } else if (typeof urlOrFilter === 'object') {
    Object.keys(urlOrFilter).sort().forEach(key => {
      const value = urlOrFilter[key];
      if (value !== null) {
        params = params.set(key, value);
      }
    });
  }

  return http.get<Page<T>>(url, { params: params });
}

@Injectable()
export class BookService {
  constructor(@Inject('BASE_URL') baseUrl: string) {

  }

  list(): Observable<Page<IBook>> {
    return queryPaginated<IBook>(this.http, this.baseUrl, urlOrfilter);
  }
}

