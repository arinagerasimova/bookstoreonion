import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { User } from '../model/user';
import { Observable,ReplaySubject,of, from } from 'rxjs';
import {  RequestOptions,  Headers, Http } from '@angular/http';
import { Router } from '@angular/router';

@Injectable()
export class AuthenticationService {
    constructor(private http: HttpClient) {
     }

    login(username: string, password: string,grant_type:string) {
        const httpOptions = {
            headers: new HttpHeaders({
              'Content-Type':  'application/x-www-form-urlencoded'
            })
          };
        return this.http.post<any>(`api/token`,
        `grant_type=${grant_type}&username=${username}&password=${password}`, httpOptions)
            .pipe(map(result => {
                // login successful if there's a jwt token in the response
                if (result && result.access_token) {
                    // store user details and jwt token in local storage to keep user logged in between page refreshes
                    localStorage.setItem('token', result.access_token);
                }
                return result;
            }));
            
    }
    logout() {
        localStorage.removeItem('username');
        // remove user from local storage to log user out
        localStorage.removeItem('token');
    }
    register(user: User) {
        debugger;
        return this.http.post(`api/account/register`, user);
    }

}