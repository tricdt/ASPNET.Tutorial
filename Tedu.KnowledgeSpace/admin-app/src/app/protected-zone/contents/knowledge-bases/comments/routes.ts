import { Routes } from '@angular/router';

export default [
  {
    path: '',
    loadComponent: () =>
      import('./comments').then((m) => m.Comments),
  },
] as Routes;