import { Routes } from '@angular/router';

export default [
  {
    path: '',
    loadComponent: () =>
      import('./monthly-new-kbs').then((m) => m.MonthlyNewKbs),
  },
] as Routes;