import { Component, OnInit } from '@angular/core';
import { BookService } from 'src/app/service/book.service';
import { OrderService } from 'src/app/service/order.service';
import { Book } from 'src/app/model/book';

@Component({
  selector: 'app-orderset',
  templateUrl: './orderset.component.html',
  styleUrls: ['./orderset.component.css']
})
export class OrdersetComponent implements OnInit {
  
  book: Book[] = [];
  constructor(private orderService: OrderService) { 
    this.orderService.getBook().subscribe(res => {
      this.book = res;
    })
  }

  ngOnInit() {
  }
  AddUserInfo()
  {
    
  }
}
