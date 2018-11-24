import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HttpService } from './http.service'
import { Http, Response, RequestOptions, Headers, ResponseContentType } from '@angular/http';
import { Router } from '@angular/router';
import { catchError, map, tap } from 'rxjs/operators';

declare var $: any;
declare var swal: any;


@Injectable()
export class BookService {

    constructor(private http: Http, private httpcline: HttpClient, private router: Router, private htmlService: HttpService) {
    }
    getBook() {
         var url = "api/bookset";
        return this.http.get(url).pipe(map(response =>
            response.json()));
    }
}