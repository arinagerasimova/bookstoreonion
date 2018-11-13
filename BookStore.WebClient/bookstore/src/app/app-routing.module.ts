import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { RegistrationComponent } from './components/view/registration/registration.component';
import { OrdersetComponent } from './components/view/orderset/orderset.component';
import { BooksetComponent } from './components/view/bookset/bookset.component';

const routes: Routes = [{
   path: 'registration', component: RegistrationComponent},
{ path: 'order', component: OrdersetComponent},
{ path: ' ', component: BooksetComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }


