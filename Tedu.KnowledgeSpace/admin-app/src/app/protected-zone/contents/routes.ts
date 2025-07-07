import { Routes } from '@angular/router';

export default [
  {
    path: 'categories',
    loadComponent: () =>
      import('./categories/categories').then((m) => m.Categories),
  },
  {
    path: 'knowledge-bases',
    loadChildren: () =>
      import('./knowledge-bases/routes').then((m) => m.default),
  },
] as Routes;
