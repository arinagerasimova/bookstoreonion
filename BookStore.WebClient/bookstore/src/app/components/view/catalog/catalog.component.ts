import { Component, OnInit } from '@angular/core';
import {GenreService} from 'src/app/service/genre.service';
import {Genre} from 'src/app/model/genre';
import { HttpClient} from '@angular/common/http';
import { HttpService} from 'src/app/service/http.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-catalog',
  templateUrl: './catalog.component.html',
  providers: [HttpService]
})
export class CatalogComponent implements OnInit {
  
  genre:Genre[]=[];
  constructor(private httpService: HttpService,
    private route: ActivatedRoute) {
        this.httpService.getGenre().subscribe(res => {
            this.genre = res;
        });
  }

  ngOnInit() {
    
    
  }

}
