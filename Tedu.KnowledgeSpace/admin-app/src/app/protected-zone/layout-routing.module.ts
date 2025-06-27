import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LayoutComponent } from './layout.component';
import { AuthGuard } from '@app/shared/guard/auth.guard';
import { BrowserAnimationsModule, provideAnimations } from '@angular/platform-browser/animations';

const routes: Routes = [
  {
    path: '',
    component: LayoutComponent,
    children: [
      { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
      {
        path: 'dashboard',
        loadChildren: () => import('./dashboard/dashboard.module').then((m) => m.DashboardModule),
        data: {
          functionCode: 'DASHBOARD'
        },
        canActivate: [],
      },
      {
        path: 'contents',
        loadChildren: () => import('./contents/contents.module').then((m) => m.ContentsModule),
        data: {
          functionCode: 'CONTENT'
        },
      },
      {
        path: 'systems',
        loadChildren: () => import('./systems/systems.module').then((m) => m.SystemsModule),
        data: {
          functionCode: 'SYSTEM'
        },
      },
      {
        path: 'statistics',
        loadChildren: () => import('./statistics/statistics.module').then((m) => m.StatisticsModule),
        data: {
          functionCode: 'STATISTIC'
        },
      }
    ]
  }
];
@NgModule({
  imports: [RouterModule.forChild(routes), ],
  exports: [RouterModule],
  providers:[
  ]
})
export class LayoutRoutingModule {}
