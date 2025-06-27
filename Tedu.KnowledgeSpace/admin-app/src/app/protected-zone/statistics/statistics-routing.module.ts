import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { MonthlyNewKbsComponent } from "./monthly-new-kbs/monthly-new-kbs.component";
import { MonthlyNewMembersComponent } from "./monthly-new-members/monthly-new-members.component";
import { MonthlyNewCommentsComponent } from "./monthly-new-comments/monthly-new-comments.component";

const routes: Routes = [
    {
        path: '',
        component: MonthlyNewKbsComponent
    },
    {
        path: 'monthly-newkbs',
        component: MonthlyNewKbsComponent,
        data: {
            functionCode: 'STATISTIC_MONTHLY_NEWKB'
        },
        canActivate: []
    },
    {
        path: 'monthly-registers',
        component: MonthlyNewMembersComponent,
        data: {
            functionCode: 'STATISTIC_MONTHLY_NEWMEMBER'
        },
        canActivate: []
    },
    {
        path: 'monthly-comments',
        component: MonthlyNewCommentsComponent,
        data: {
            functionCode: 'STATISTIC_MONTHLY_COMMENT'
        },
        canActivate: []
    }
];
@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})
export class StatisticsRoutingModule { }