import { Routes } from '@angular/router';

export default [
  {
    path: '',
    loadComponent: () =>
      import('./monthly-new-members').then((m) => m.MonthlyNewMembers),
  },
] as Routes;