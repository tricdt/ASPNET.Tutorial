import { Routes } from "@angular/router";

export default [
    {
        path: '',
        loadComponent: () => import('./not-found').then((m) => m.NotFound),
    }
] as Routes;