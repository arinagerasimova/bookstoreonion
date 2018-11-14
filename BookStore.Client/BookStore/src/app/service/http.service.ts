import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { Observable } from 'rxjs';
  
@Injectable()
export class HttpService{
  
    constructor(private http: HttpClient){ }
      
    getData()
    {
        return this.http.get("http://localhost:55656/")
    }
}