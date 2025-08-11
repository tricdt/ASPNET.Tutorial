import { Routes } from '@angular/router';
import { AppLayout } from './layout/components/app.layout';
import { Dashboard } from './pages/dashboard/dashboard';
import { Documentation } from './pages/documentation/documentation';
import { Login } from './pages/auth/login';
import { AuthCallback } from './pages/auth/auth-callback';
import { ServerError } from './pages/server-error/server-error';
import { AccessDenied } from './pages/access-denied/access-denied';
import { NotFound } from './pages/notfound/notfound';

export const routes: Routes = [
  {
    path: '',
    loadChildren: () => import('./protected-zone/protected-zone.routes'),
    data: {
      functionCode: 'DASHBOARD'
    }
  },
  {
    path: 'login',
    component: Login
  },
  {
    path: 'auth-callback',
    component: AuthCallback
  },
  {
    path: 'error',
    component: ServerError
  },
  {
    path: 'access-denied',
    component: AccessDenied
  },
  {
    path: 'not-found',
    component: NotFound
  },
  {
    path: '**',
    redirectTo: 'not-found'
  }

  // {
  //   path: '',
  //   component: AppLayout,
  //   children: [
  //     { path: '', component: Dashboard },
  //     { path: 'documentation', component: Documentation },
  //     { path: 'pages', loadChildren: () => import('./pages/pages.routes') },
  //   ],
  // },
];
