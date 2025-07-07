import { Routes } from '@angular/router';

export default [
  {
    path: '',
    loadComponent: () => import('./access-denied').then((m) => m.AccessDenied),
  },
] as Routes;
