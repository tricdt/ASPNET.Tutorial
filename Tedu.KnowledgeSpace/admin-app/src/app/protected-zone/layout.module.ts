import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LayoutComponent } from './layout.component';
import { LayoutRoutingModule } from './layout-routing.module';
import { HeaderComponent } from "./components/header/header.component";
import { NgbDropdownModule } from '@ng-bootstrap/ng-bootstrap';
import { SidebarComponent } from "./components/sidebar/sidebar.component";



@NgModule({
  declarations: [LayoutComponent,
    HeaderComponent, 
    SidebarComponent
  ],
  imports: [
    CommonModule,
    LayoutRoutingModule,
    NgbDropdownModule,
  ]
})
export class ProtectedZoneModule { }
