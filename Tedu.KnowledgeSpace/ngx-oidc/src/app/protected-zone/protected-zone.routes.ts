import { Routes } from '@angular/router';

export default [
  {
    path: '',
    loadComponent: () => import('./layout').then((m) => m.Layout),
  },
] as Routes;
