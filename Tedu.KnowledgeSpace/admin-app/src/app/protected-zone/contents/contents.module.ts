import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { KnowledgeBasesComponent } from './knowledge-bases/knowledge-bases.component';
import { CommentsComponent } from './knowledge-bases/comments/comments.component';
import { CommentsDetailComponent } from './knowledge-bases/comments-detail/comments-detail.component';
import { KnowledgeBasesDetailComponent } from './knowledge-bases/knowledge-bases-detail/knowledge-bases-detail.component';
import { ReportsComponent } from './knowledge-bases/reports/reports.component';
import { ReportsDetailComponent } from './knowledge-bases/reports-detail/reports-detail.component';
import { ContentsRoutingModule } from './contents-routing.module';



@NgModule({
  declarations: [KnowledgeBasesComponent,
    CommentsComponent,
    CommentsDetailComponent,
    KnowledgeBasesDetailComponent,
    ReportsComponent,
    ReportsDetailComponent
  ],
  imports: [
    CommonModule, ContentsRoutingModule
  ]
})
export class ContentsModule { }
