import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, of, from } from 'rxjs';
import { GenreService } from './genre.service'
import { Http, Response, RequestOptions, Headers, ResponseContentType } from '@angular/http';
import { Router } from '@angular/router';
import { Location } from '@angular/common';
import { catchError, map, tap } from 'rxjs/operators';

declare var $: any;
declare var swal: any;


@Injectable()
export class HttpService {

    constructor(private http: Http, private httpcline: HttpClient, private router: Router, private genreService: GenreService) {
    }
    getData() {
        return this.httpcline.get("http://localhost:55656/")
    }
    getGenre() {
        var headers = new Headers({ 'Content-Type': '', 'Authorization': "" + this.genreService.getToken() });
        var url = "http://localhost:55656/";
        return this.http.get(url).pipe(map(response =>
            response.json()));
    }

}