import {Injectable} from '@angular/core';
import { Http, RequestOptions, Response, Headers } from '@angular/http';
import {HttpClient, HttpParams} from '@angular/common/http';
import {Genre} from '../model/genre';
import {Observable, ReplaySubject} from 'rxjs';
import { Location } from '@angular/common';
import { Router } from '@angular/router';
   
@Injectable()
 export class GenreService{
    headers: any = new Headers({ 'Content-Type': '', 'Authorization': ' ' + localStorage.getItem("token") });
    
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
}