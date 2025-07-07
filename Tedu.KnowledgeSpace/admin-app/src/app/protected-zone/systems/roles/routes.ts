import { Routes } from '@angular/router';

export default [
  {
    path: '',
    loadComponent: () => import('./roles').then((m) => m.Roles),
  },
] as Routes;