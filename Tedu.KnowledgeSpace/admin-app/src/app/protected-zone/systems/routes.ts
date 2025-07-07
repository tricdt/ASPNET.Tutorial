import { Routes } from '@angular/router';

export default [
  {
    path: 'functions',
    loadChildren: () => import('./functions/routes').then((m) => m.default),
  },
  {
    path: 'permissions',
    loadChildren: () => import('./permissions/routes').then((m) => m.default),
  },
  {
    path: 'roles',
    loadChildren: () => import('./roles/routes').then((m) => m.default),
  },
  {
    path: 'users',
    loadChildren: () => import('./users/routes').then((m) => m.default),
  },
] as Routes;