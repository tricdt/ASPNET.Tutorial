import { Routes } from '@angular/router';

export default [
    { path: 'monthly-registers', loadChildren: () => import('./monthly-new-members/routes').then((m) => m.default) },
    { path: 'monthly-comments', loadChildren: () => import('./monthly-new-comments/routes').then((m) => m.default) },
    { path: 'monthly-newkbs', loadChildren: () => import('./monthly-new-kbs/routes').then((m) => m.default) },
] as Routes;