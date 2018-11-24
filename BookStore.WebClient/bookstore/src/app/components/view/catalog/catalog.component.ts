import { Component, OnInit } from '@angular/core';
import {Genre} from 'src/app/model/genre';
import { HttpClient} from '@angular/common/http';
import { GenreService} from 'src/app/service/genre.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-catalog',
  templateUrl: './catalog.component.html',
  providers: [GenreService]
})
export class CatalogComponent implements OnInit {
  
  genre:Genre[]=[];
  constructor(private genreService: GenreService,
    private route: ActivatedRoute) {
        this.genreService.getGenre().subscribe(res => {
            this.genre = res;
        });
  }

  ngOnInit() {
    
    
  }

}
