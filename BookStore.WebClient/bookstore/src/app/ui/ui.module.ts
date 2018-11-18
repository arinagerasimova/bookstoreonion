import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LayoutComponent } from './layout/layout.component';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';
import { AppRoutingModule } from 'src/app/app-routing.module';
import {AuthenticationService} from '../service/authentication.service';

@NgModule({
  imports: [
    CommonModule,AppRoutingModule
  ],
  declarations: [LayoutComponent, HeaderComponent, FooterComponent],
  providers: [AuthenticationService],
  exports: [LayoutComponent]
})
export class UiModule { }