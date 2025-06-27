import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { UsersComponent } from "./users/users.component";
import { FunctionsComponent } from "./functions/functions.component";
import { RolesComponent } from "./roles/roles.component";
import { PermissionsComponent } from "./permissions/permissions.component";


const routes: Routes = [
    {
        path: '',
        component: UsersComponent
    },
    {
        path: 'users',
        component: UsersComponent,
        data: {
            functionCode: 'SYSTEM_USER'
        },
        canActivate: []
    },
    {
        path: 'functions',
        component: FunctionsComponent,
        data: {
            functionCode: 'SYSTEM_FUNCTION'
        },
        canActivate: []
    },
    {
        path: 'roles',
        component: RolesComponent,
        data: {
            functionCode: 'SYSTEM_ROLE'
        },
        canActivate: []
    },
    {
        path: 'permissions',
        component: PermissionsComponent,
        data: {
            functionCode: 'SYSTEM_PERMISSION'
        },
        canActivate: []
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class SystemsRoutingModule {}