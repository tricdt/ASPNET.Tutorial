import { Routes } from '@angular/router';
import { Access } from './auth/access/access';
import { Login } from './auth/login/login';
import { Error } from './auth/error/error';
import { PagesLayout } from './page-layout/page.layout';

export default [
  { path: 'auth', loadChildren: () => import('./auth/auth.routes') },
  {
    path: 'uikit',
    component: PagesLayout,
    loadChildren: () => import('./uikit/uikit.routes'),
  },
] as Routes;
