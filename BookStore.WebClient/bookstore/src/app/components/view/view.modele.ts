import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BooksetComponent } from './bookset/bookset.component';
import { OrdersetComponent } from './orderset/orderset.component';
import { CatalogComponent } from './catalog/catalog.component';
import { RegistrationComponent } from './registration/registration.component';

@NgModule({
  imports: [ CommonModule],
  declarations: [RegistrationComponent,BooksetComponent, 
    OrdersetComponent, OrdersetComponent,CatalogComponent],
  exports: [RegistrationComponent,BooksetComponent, 
    OrdersetComponent, OrdersetComponent,CatalogComponent]
})

export class ViewModule { }