import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ContentsRoutingModule } from './contents-routing.module';
import { CategoriesComponent } from './categories/categories.component';
import { ButtonModule } from 'primeng/button';
@NgModule({
  declarations: [CategoriesComponent],
  imports: [
    CommonModule, 
    ContentsRoutingModule,
    ButtonModule,
  ]
})
export class ContentsModule { }
