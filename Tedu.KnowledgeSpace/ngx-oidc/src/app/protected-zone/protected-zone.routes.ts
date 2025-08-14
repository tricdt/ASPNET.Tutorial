import { Routes } from '@angular/router';
import { Dashboard } from './dashboard/dashboard';

export default [
  {
    path: '',
    loadComponent: () => import('./layout').then((m) => m.Layout),
    children: [
      { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
      { path: 'dashboard', component: Dashboard },
      {
        path: 'contents',
        loadChildren: () => import('./contents/contents.routes'),
      },
      {
        path: 'statistics',
        loadChildren: () => import('./statistics/statistics.routes'),
      },
      {
        path: 'systems',
        loadChildren: () => import('./systems/systems.routes'),
      },
    ],
  },
] as Routes;
