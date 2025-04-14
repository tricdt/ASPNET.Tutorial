import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MainComponent } from './main.component';
import { RouterModule, Routes } from '@angular/router';
import { UserComponent } from './user/user.component';

export const mainRoutes: Routes = [
  {
    //localhost:4200/main
    path: '', component: MainComponent, children: [
      //localhost:4200/main
      { path: '', redirectTo: 'home', pathMatch: 'full' },
      //localhost:4200/main/user
      { path: 'user', loadChildren: () => import('./user/user.module').then(m => m.UserModule) }
    ]
  }

]
@NgModule({
  declarations: [MainComponent],
  imports: [
    CommonModule, RouterModule.forChild(mainRoutes) // Register the routes for this module
  ]
})
export class MainModule { }
