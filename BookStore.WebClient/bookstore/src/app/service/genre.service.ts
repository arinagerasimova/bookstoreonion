

import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HttpService } from './http.service'
import { Http} from '@angular/http';
import { Router } from '@angular/router';
import { map} from 'rxjs/operators';

declare var $: any;
declare var swal: any;


@Injectable()
export class GenreService {

    constructor(private http: Http, private httpcline: HttpClient, private router: Router, private httpService: HttpService) {
    }
    getGenre() {
        
        var url = "api/genre";
        return this.http.get(url).pipe(map(response =>
            response.json()));
    }
    
}