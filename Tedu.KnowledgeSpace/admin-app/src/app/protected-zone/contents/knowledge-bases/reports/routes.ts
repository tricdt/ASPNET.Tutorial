import { Routes } from '@angular/router';

export default [
  {
    path: '',
    loadComponent: () =>
      import('./reports').then((m) => m.Reports),
  },
] as Routes;