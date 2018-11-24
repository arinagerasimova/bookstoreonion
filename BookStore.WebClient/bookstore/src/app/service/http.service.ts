import { Injectable } from '@angular/core';
import { Http, RequestOptions, Response, Headers } from '@angular/http';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Genre } from '../model/genre';
import { Observable, ReplaySubject } from 'rxjs';
import { Location } from '@angular/common';
import { Router } from '@angular/router';

@Injectable()
export class HttpService {
    headers: any = new Headers({ 'Content-Type': 'application/json', 'Authorization': `Bearer ${this.getToken()}` });

    options: any = new RequestOptions({ headers: this.headers });
    public loggedIn = false;
    public currentUser;
    isBusy: boolean = false;
    public token: string;
    private currentUserSubj = new ReplaySubject<any>(1);
    constructor(private router: Router, private http: Http, private _location: Location) {

    }
    public getToken() {
        if (this.token && this.token.length > 0)
            return this.token;
        this.token = localStorage.getItem('token');
        return this.token;
    }

    public isAuthenticated() {
        if (this.getToken() == null)
            return false;
        return true;
    }

    public post(url: string, body: any = {}) {
        const httpOptions = { headers: this.headers }
        return this.http.post("api/orders/create", body, httpOptions);
    }

}