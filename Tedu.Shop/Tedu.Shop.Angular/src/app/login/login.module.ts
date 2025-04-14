import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './login.component';
import { Router, RouterModule, Routes } from '@angular/router';
export const routes: Routes = [
  //localhost:4200/login
  { path: '', component: LoginComponent }
];

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(routes) // Register the routes for this module
  ],
  declarations: [LoginComponent]
})
export class LoginModule { }
