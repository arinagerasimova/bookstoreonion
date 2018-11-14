import { Component, OnInit } from '@angular/core';
import {GenreService} from 'src/app/service/genre.service';
import {Genre} from 'src/app/model/genre';
// import { HttpClient} from '@angular/common/http';
import { HttpService} from 'src/app/service/http.service';

@Component({
  selector: 'app-catalog',
  templateUrl: './catalog.component.html',
  styleUrls: ['./catalog.component.css'],
  providers: [HttpService]
})
export class CatalogComponent implements OnInit {
  
  genre:Genre[]=[];
  error:any;
  constructor(private httpService: HttpService){}

  ngOnInit() {
    
    this.httpService.getData().subscribe(data => this.genre=data as Genre[] ,
      error => {this.error = error.message; console.log(error);} );
    debugger;
  }

}
