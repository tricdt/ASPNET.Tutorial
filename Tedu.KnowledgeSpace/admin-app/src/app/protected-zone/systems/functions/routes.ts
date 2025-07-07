import { Routes } from '@angular/router';

export default [
  {
    path: '',
    loadComponent: () => import('./functions').then((m) => m.Functions),
  },
] as Routes;