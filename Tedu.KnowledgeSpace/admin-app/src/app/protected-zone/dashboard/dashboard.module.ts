import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DashboardRoutingModule } from './dashboard-routing.module';
import { DashboardComponent } from './dashboard.component';
import { StatModule } from '@app/shared/modules/stat/stat.module';
import { NgbAlertModule, NgbCarouselModule } from '@ng-bootstrap/ng-bootstrap';
import { ChatComponent, NotificationComponent, TimelineComponent } from './components';



@NgModule({
  declarations: [DashboardComponent,
    TimelineComponent,
    ChatComponent,
    NotificationComponent
  ],
  imports: [
    CommonModule, 
    DashboardRoutingModule,
    StatModule,
    NgbCarouselModule,
    NgbAlertModule
  ]
})
export class DashboardModule { }
