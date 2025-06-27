import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ContentsRoutingModule } from './contents-routing.module';
import { CategoriesComponent } from './categories/categories.component';

@NgModule({
  declarations: [CategoriesComponent],
  imports: [
    CommonModule, ContentsRoutingModule
  ]
})
export class ContentsModule { }
