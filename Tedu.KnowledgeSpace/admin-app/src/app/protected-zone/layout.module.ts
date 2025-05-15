import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LayoutComponent } from './layout.component';
import { LayoutRoutingModule } from './layout-routing.module';
import { HeaderComponent } from "./components/header/header.component";
import { NgbDropdownModule } from '@ng-bootstrap/ng-bootstrap';



@NgModule({
  declarations: [LayoutComponent, HeaderComponent],
  imports: [
    CommonModule, LayoutRoutingModule,
    NgbDropdownModule,
  ]
})
export class ProtectedZoneModule { }
