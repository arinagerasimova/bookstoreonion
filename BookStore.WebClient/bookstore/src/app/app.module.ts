import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
 
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './components/app.component';
import { UiModule } from './ui/ui.module';
import { ViewModule } from './components/view/view.modele';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    UiModule,ViewModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
