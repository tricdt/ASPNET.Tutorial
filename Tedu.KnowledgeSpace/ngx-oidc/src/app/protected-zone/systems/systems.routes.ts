import { Routes } from '@angular/router';
import { Functions } from './functions/functions';
import { Roles } from './roles/roles';
import { Users } from './users/users';
import { Permissions } from './permissions/permissions';
export default [
  { path: 'functions', component: Functions },
  { path: 'roles', component: Roles },
  { path: 'users', component: Users },
  { path: 'permissions', component: Permissions }
] as Routes;
