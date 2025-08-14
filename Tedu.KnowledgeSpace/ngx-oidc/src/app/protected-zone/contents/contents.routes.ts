import { Routes } from '@angular/router';
import { Categories } from './categories/categories';

export default [
  { path: 'categories', loadChildren: () => import('./categories/categories.routes') },
  { path: 'knowledge-bases', loadChildren: () => import('./knowledge-bases/knowledge-bases.routes') }
] as Routes;
