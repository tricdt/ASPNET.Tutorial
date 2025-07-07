import { Routes } from '@angular/router';

export default [
    {
        path: '',
        loadComponent: () =>
            import('./knowledge-bases').then((m) => m.KnowledgeBases),
    },
    {
        path: 'comments',
        loadChildren: () =>
            import('./comments/routes').then((m) => m.default),
    },
    {
        path: 'reports',
        loadChildren: () =>
            import('./reports/routes').then((m) => m.default),
    },
] as Routes;
