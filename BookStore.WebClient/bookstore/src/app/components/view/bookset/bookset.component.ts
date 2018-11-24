import { Component, OnInit } from '@angular/core';
import { Book } from 'src/app/model/book'
import { BookService } from 'src/app/service/book.service';
import { OrderService } from 'src/app/service/order.service';
import { ActivatedRoute, Router } from '@angular/router';
import { first } from 'rxjs/operators';
import { HttpService } from 'src/app/service/http.service';
@Component({
    selector: 'app-bookset',
    templateUrl: './bookset.component.html'
})
export class BooksetComponent implements OnInit {
    book: Book[] = [];
    constructor(private bookService: BookService,
        private route: ActivatedRoute, private router: Router, private orderService: OrderService, private httpService: HttpService) {
        this.bookService.getBook().subscribe(res => {
            this.book = res;
        });
    }

    ngOnInit() {
    }

    order(id: number) {
        debugger;
        if (this.httpService.isAuthenticated()) {

            this.orderService.order(id)
                .pipe(first())
                .subscribe(
                    data => {
                        this.router.navigate(['']);
                    },

                    error => {
                    });
        }
        else this.router.navigate(['login']);


    }
}
