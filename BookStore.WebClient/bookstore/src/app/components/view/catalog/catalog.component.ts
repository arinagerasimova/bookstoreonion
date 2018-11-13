import { Component, OnInit } from '@angular/core';
import {GenreService} from 'src/app/service/genre.service';
import {Genre} from 'src/app/model/genre';


@Component({
  selector: 'app-catalog',
  templateUrl: './catalog.component.html',
  styleUrls: ['./catalog.component.css'],
  providers: [GenreService]
})
export class CatalogComponent implements OnInit {

  constructor(private genreService : GenreService) { }

  ngOnInit() {
    debugger;
    var t = this.genreService.getGenre();
  }

}
