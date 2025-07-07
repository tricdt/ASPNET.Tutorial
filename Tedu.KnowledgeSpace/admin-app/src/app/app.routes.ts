import { Routes } from '@angular/router';
import { AuthGuard } from './shared/guard/auth.guard';

export const routes: Routes = [
  {
    path: '',
    loadChildren: () =>
      import('./protected-zone/routes').then((m) => m.default),
    data: {
      functionCode: 'DASHBOARD',
    },
    canActivate: [AuthGuard],
  },
  {
    path: 'login',
    loadChildren: () => import('./login/routes').then((m) => m.default),
  },
  {
    path: 'auth-callback',
    loadChildren: () => import('./auth-callback/routes').then((m) => m.default),
  },
  {
    path: 'error',
    loadChildren: () => import('./server-error/routes').then((m) => m.default),
  },
  {
    path: 'access-denied',
    loadChildren: () => import('./access-denied/routes').then((m) => m.default),
  },
  {
    path: 'not-found',
    loadChildren: () => import('./not-found/routes').then((m) => m.default),
  },
  { path: '**', redirectTo: 'not-found' },
];
