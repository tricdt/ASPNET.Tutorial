import { Routes } from '@angular/router';

export default [
  {
    path: '',
    loadComponent: () => import('./permissions').then((m) => m.Permissions),
  },
] as Routes;