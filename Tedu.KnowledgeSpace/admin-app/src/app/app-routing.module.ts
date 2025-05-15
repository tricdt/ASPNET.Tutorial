import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
const routes: Routes = [
  {
    path: '',
    loadChildren: () => import('./protected-zone/layout.module').then((m) => m.ProtectedZoneModule),
  },
  { path: 'login', loadChildren: () => import('./login/login.module').then((m) => m.LoginModule) },
  { path: 'signup', loadChildren: () => import('./signup/signup.module').then((m) => m.SignupModule) },
  { path: 'error', loadChildren: () => import('./server-error/server-error.module').then((m) => m.ServerErrorModule) },
  { path: 'not-found', loadChildren: () => import('./not-found/not-found.module').then((m) => m.NotFoundModule) },
  {
    path: 'access-denied',
    loadChildren: () => import('./access-denied/access-denied.module').then((m) => m.AccessDeniedModule)
  },
  {
    path: 'auth-callback',
    loadChildren: () => import('./auth-callback/auth-callback.module').then((m) => m.AuthCallbackModule)
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
