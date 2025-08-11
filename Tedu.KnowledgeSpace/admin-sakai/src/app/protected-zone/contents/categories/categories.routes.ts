import { Routes } from '@angular/router';
import { Create } from './create';
import { Edit } from './edit';
export default [
  { path: 'create', component: Create },
  { path: 'edit', component: Edit }
] as Routes;
