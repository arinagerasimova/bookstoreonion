import { Component, OnInit } from '@angular/core';
import {Book} from 'src/app/model/book'
import { HttpService } from 'src/app/service/http.service';
import { ActivatedRoute } from '@angular/router';
import {CardModule} from 'primeng/card';
@Component({
  selector: 'app-bookset',
  templateUrl: './bookset.component.html'
})
export class BooksetComponent implements OnInit {

  book:Book[]=[];
  constructor(private httpService: HttpService,
    private route: ActivatedRoute) {
        this.httpService.getBook().subscribe(res => {
            this.book = res;
        });
  }
  ngOnInit() {
  }

}
