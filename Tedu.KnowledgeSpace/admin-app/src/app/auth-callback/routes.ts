import { Routes } from "@angular/router";

export default [
    {
        path: '',
        loadComponent: () => import('./auth-callback').then((m) => m.AuthCallback),
    }
] as Routes;