import { Component, OnInit } from '@angular/core';
import { tokenName } from '@angular/compiler';
import { AuthenticationService } from 'src/app/service/authentication.service';
import { Router } from '@angular/router';
import { UserService } from 'src/app/service/user.service';
import { HttpService } from 'src/app/service/http.service';

@Component({
  selector: 'app-header',
   templateUrl: './header.component.html'
  // styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
userName: string='';
buttonName: string='';
  constructor(private router: Router, private authenticationService: AuthenticationService,
    private userservice:UserService,private httpService: HttpService) {
  }

   ngOnInit()
   {
     debugger;
    if (this.httpService.isAuthenticated())
    {
      
      this.buttonName='выйти';
      this.userservice.getUserName().subscribe(res => {
        this.userName = res;
    });
    
    }
    else   this.buttonName='войти';
   }
  clicking()
  {
    if (this.httpService.isAuthenticated())
      {
        this.authenticationService.logout();
        this.userName='';
      }
      else this.router.navigate(['/login']);
  }
}
