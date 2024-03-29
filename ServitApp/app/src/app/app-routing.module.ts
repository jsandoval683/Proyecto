import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ClienteComponent } from './cliente/cliente.component';
import { LoginComponent } from './login/login.component';
import { SignupComponent } from './signup/signup.component';



const routes: Routes = [
  { path: '', redirectTo: '/login', pathMatch:'full'},
  { path: 'home', component: HomeComponent},
  { path: 'cliente', component: ClienteComponent},
  { path: 'login', component: LoginComponent },
  { path: 'signup', component: SignupComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
  
})
export class AppRoutingModule { }
