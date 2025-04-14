import { Routes } from '@angular/router';

export const routes: Routes = [
    //localhost:4200
    { path: '', redirectTo: 'login', pathMatch: 'full' },
    //localhost:4200/login
    { path: 'login', loadChildren: () => import('./login/login.module').then(m => m.LoginModule) },
    //localhost:4200/main
    { path: 'main', loadChildren: () => import('./main/main.module').then(m => m.MainModule) }
];
