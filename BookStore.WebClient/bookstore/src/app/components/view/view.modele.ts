import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BooksetComponent } from './bookset/bookset.component';
import { OrdersetComponent } from './orderset/orderset.component';
import { CatalogComponent } from './catalog/catalog.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule }   from '@angular/common/http';
import { AppRoutingModule } from 'src/app/app-routing.module';
import { BrowserModule } from '@angular/platform-browser';
import {CardModule} from 'primeng/card';
import {ButtonModule} from 'primeng/button';

@NgModule({
  imports: [ CommonModule,CardModule,HttpClientModule,FormsModule,BrowserModule,
    HttpClientModule,ReactiveFormsModule,AppRoutingModule, ButtonModule],
  declarations: [BooksetComponent, 
    OrdersetComponent, OrdersetComponent,CatalogComponent],
  exports: [BooksetComponent, 
    OrdersetComponent, OrdersetComponent,CatalogComponent]
})

export class ViewModule { }