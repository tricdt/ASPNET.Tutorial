import { Routes } from '@angular/router';
import { Login } from './login/login';
import { AuthCallback } from './auth-callback/auth-callback';
import { ServerError } from './server-error/server-error';
import { AccessDenied } from './access-denied/access-denied';
import { NotFound } from './not-found/not-found';
import { authGuard } from './shared/guards/auth-guard';
export const routes: Routes = [
  {
    path: '',
    loadChildren: () => import('./protected-zone/protected-zone.routes'),
    canActivate: [authGuard],
  },
  {
    path: 'login',
    component: Login,
  },
  {
    path: 'auth-callback',
    component: AuthCallback,
  },
  {
    path: 'error',
    component: ServerError,
  },
  {
    path: 'access-denied',
    component: AccessDenied,
  },
  {
    path: 'not-found',
    component: NotFound,
  },
  {
    path: '**',
    redirectTo: 'not-found',
  },
];

//   {
//     path: '',
//     loadChildren: () => import('./protected-zone/protected-zone.routes'),
//     data: {
//       functionCode: 'DASHBOARD'
//     },
//     canActivate: [AuthGuard]
//   },
//   {
//     path: 'login',
//     component: Login
//   },
//   {
//     path: 'auth-callback',
//     component: AuthCallback
//   },
//   {
//     path: 'error',
//     component: ServerError
//   },
//   {
//     path: 'access-denied',
//     component: AccessDenied
//   },
//   {
//     path: 'not-found',
//     component: NotFound
//   },
//   {
//     path: '**',
//     redirectTo: 'not-found'
//   }
