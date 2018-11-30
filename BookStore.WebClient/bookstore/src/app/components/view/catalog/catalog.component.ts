import { Component, OnInit } from '@angular/core';
import {Genre} from 'src/app/model/genre';
import { HttpClient} from '@angular/common/http';
import { GenreService} from 'src/app/service/genre.service';
import { ActivatedRoute } from '@angular/router';
import { BooksetComponent } from '../bookset/bookset.component';
import { BookService } from 'src/app/service/book.service';

@Component({
  selector: 'app-catalog',
  templateUrl: './catalog.component.html',
  providers: [GenreService]
})
export class CatalogComponent implements OnInit {
  
  genre:Genre[]=[];
  constructor(private bookService: BookService,private genreService: GenreService,
    private route: ActivatedRoute,private bookset:BooksetComponent) {
        this.genreService.getGenre().subscribe(res => {
            this.genre = res;
        });
  }

  ngOnInit() {
  }

  changeGenre(genre: string)
  {
    this.bookset.genreName=genre;
    this.bookset.getBookset();
  }

}
