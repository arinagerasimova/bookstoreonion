import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { RegistrationComponent } from './components/registration/registration.component';
import { LoginComponent } from './components/login/login.component';
import { OrdersetComponent } from './components/view/orderset/orderset.component';
import { BooksetComponent } from './components/view/bookset/bookset.component';
import { AuthGuard } from './_guards/auth.guard';

const routes: Routes = [{
   path: 'registration', component: RegistrationComponent},
{ path: 'order', component: OrdersetComponent},
{ path: '', component: BooksetComponent},
{ path: 'login', component: LoginComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }


