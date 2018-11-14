import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './components/app.component';
import { UiModule } from './ui/ui.module';
import { ViewModule } from './components/view/view.modele';
import {GenreService} from './service/genre.service';

import { HttpModule } from '@angular/http';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    UiModule,ViewModule,
    HttpClientModule,
    HttpModule
  ],
  providers: [GenreService],
  bootstrap: [AppComponent]
})
export class AppModule { }

