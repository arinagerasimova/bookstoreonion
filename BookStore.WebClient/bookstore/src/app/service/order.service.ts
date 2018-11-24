import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { User } from '../model/user';
import { Observable, ReplaySubject, of, from } from 'rxjs';
import { RequestOptions, Headers, Http } from '@angular/http';
import { Router } from '@angular/router';
import { HttpService } from './http.service';
import { OrderBook } from '../model/orderbook';

@Injectable()
export class OrderService {
    //headers: any = new Headers({ 'Content-Type': 'application/json','Authorization': 'bearer ' + localStorage.getItem("token") });
    constructor(private router: Router, private http: HttpClient, private httpService: HttpService) {
    }
    // 'Content-Type': 'application/json'  `IdBook=${id}`
    order(id: number) {
        debugger;
        const body = { IdBook: id };
        return this.httpService.post("api/orders/create", body);       
    }
}