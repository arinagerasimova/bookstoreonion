import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BooksetComponent } from './bookset/bookset.component';
import { OrdersetComponent } from './orderset/orderset.component';
import { CatalogComponent } from './catalog/catalog.component';

@NgModule({
  imports: [
    CommonModule
  ],
  declarations: [BooksetComponent, OrdersetComponent, OrdersetComponent],
  exports: [ViewModule]
})

export class ViewModule { }