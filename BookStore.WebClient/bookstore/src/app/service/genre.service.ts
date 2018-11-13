import {Injectable} from '@angular/core';
import {HttpClient, HttpParams} from '@angular/common/http';
import {Genre} from '../model/genre';
import {Observable} from 'rxjs';
   
@Injectable()
export class GenreService{
    private baseUrl = "http://localhost:55656/";
    constructor(private http: HttpClient){ }
      
    getGenre(){
        return this.http.get(this.baseUrl+"api/home");
    }
  
    createGenre(genre: Genre){
        return this.http.post(this.baseUrl, genre); 
    }
    updateGenre(id: number, genre: Genre) {
        const urlParams = new HttpParams().set("id", id.toString());
        return this.http.put(this.baseUrl, genre, { params: urlParams});
    }
    deleteGenre(id: number){
        const urlParams = new HttpParams().set("id", id.toString());
        return this.http.delete(this.baseUrl, { params: urlParams});
    } 
}