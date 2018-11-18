import { Component, OnInit } from '@angular/core';
import { tokenName } from '@angular/compiler';
import { AuthenticationService } from 'src/app/service/authentication.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-header',
   templateUrl: './header.component.html'
  // styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
userName: string=this.authenticationService.Name;
buttonName: string='';
  constructor(private router: Router, private authenticationService: AuthenticationService) {
    if (localStorage.getItem('token')!=null)
    {
      this.buttonName='выйти';
    }
    else   this.buttonName='войти';
   }

  ngOnInit() {
  }
  clicking()
  {
    if (localStorage.getItem('token')!=null)
      {
        this.authenticationService.logout();
      }
      else this.router.navigate(['/login']);
  }
}
