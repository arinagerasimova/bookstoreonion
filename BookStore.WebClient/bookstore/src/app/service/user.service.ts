import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of, from } from 'rxjs';
import { HttpService } from './http.service'
import { Http, Response, RequestOptions, Headers, ResponseContentType } from '@angular/http';
import { Router } from '@angular/router';
import { stringify } from '@angular/compiler/src/util';
import { catchError, map, tap } from 'rxjs/operators';

@Injectable()
export class UserService {
    token_str: string
    constructor(private http: Http, private httpcline: HttpClient, private router: Router, private httpService: HttpService) {
    }
    getUserName() {
        if (this.httpService.isAuthenticated()) {
            var url = "api/Account/username";
            return this.http.get(url, { headers: this.httpService.headers }).pipe(
                map(
                    response =>
                        response.json()));
        }
    }


}