import { Routes } from '@angular/router';

export default [
  {
    path: '',
    loadComponent: () => import('./layout').then((m) => m.Layout),
    children: [
      { path: '', redirectTo: 'dashboard', pathMatch: 'prefix' },
      {
        path: 'dashboard',
        loadChildren: () => import('./dashboard/routes').then((m) => m.default),
        data: {
          functionCode: 'DASHBOARD',
        },
      },
      {
        path: 'contents',
        loadChildren: () => import('./contents/routes').then((m) => m.default),
      },
      {
        path: 'statistics',
        loadChildren: () => import('./statistics/routes').then((m) => m.default),
      },
      {
        path: 'systems',
        loadChildren: () => import('./systems/routes').then((m) => m.default),
      },
    ],
  },
] as Routes;
