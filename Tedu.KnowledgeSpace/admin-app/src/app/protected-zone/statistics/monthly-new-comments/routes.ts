import { Routes } from '@angular/router';

export default [
  {
    path: '',
    loadComponent: () =>
      import('./monthly-new-comments').then((m) => m.MonthlyNewComments),
  },
] as Routes;