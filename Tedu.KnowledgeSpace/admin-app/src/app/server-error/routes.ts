import { Routes } from "@angular/router";

export default [
    {
        path: '',
        loadComponent: () => import('./server-error').then((m) => m.ServerError),
    }
] as Routes;