import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { ReactiveFormsModule }    from '@angular/forms';
import { routing } from './app-routing.module';
import { AppComponent } from './components/app.component';
import { UiModule } from './ui/ui.module';
import { ViewModule } from './components/view/view.modele';
import {GenreService} from './service/genre.service';
import {BookService} from './service/book.service';
import {AuthenticationService} from './service/authentication.service';
import {AlertService} from './service/alert.service';
import { HttpModule } from '@angular/http';
import { LoginComponent } from './components/login/login.component';
import { RegistrationComponent } from './components/registration/registration.component';
import {AuthGuard} from 'src/app/guards/auth.guard'
import { HttpService } from './service/http.service';
import { OrderService } from './service/order.service';
import { UserService } from './service/user.service';
@NgModule({
  declarations: [
    AppComponent,LoginComponent,
    RegistrationComponent
  ],
  imports: [
    BrowserModule,
    ReactiveFormsModule,
    routing,
    UiModule,ViewModule,
    HttpClientModule,
    HttpModule
  ],
  providers: [HttpService,UserService,OrderService,GenreService,BookService,AuthenticationService,AlertService,AuthGuard],
  bootstrap: [AppComponent]
})
export class AppModule { }

