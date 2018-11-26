import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { Router } from '@angular/router';
import { HttpService } from './http.service';
import { Http } from '@angular/http';

@Injectable()
export class OrderService {
    url:string="api/orders/";
    constructor(private router: Router, private httpcline: HttpClient, private httpService: HttpService,private http: Http,) {
    }
    order(id: number) {
        const body = { IdBook: id };
        return this.httpService.post(this.url+"create", body);       
    }
    numberOfOrders(){
        return this.httpService.get(this.url+"count").pipe(map(response =>
            response.json()));
    }
}