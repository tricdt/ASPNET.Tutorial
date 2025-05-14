import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { KnowledgeBasesComponent } from "./knowledge-bases/knowledge-bases.component";
import { KnowledgeBasesDetailComponent } from "./knowledge-bases/knowledge-bases-detail/knowledge-bases-detail.component";
import { CategoriesComponent } from "./categories/categories.component";
import { CommentsComponent } from "./knowledge-bases/comments/comments.component";
import { ReportsComponent } from "./knowledge-bases/reports/reports.component";

const routes: Routes = [
    {
        path: '',
        component: KnowledgeBasesComponent,
        data: {
            functionCode: 'CONTENT_KNOWLEDGEBASE'
        },
    },
    {
        path: 'knowledge-bases',
        component: KnowledgeBasesComponent,
        data: {
            functionCode: 'CONTENT_KNOWLEDGEBASE'
        },
    },
    {
        path: 'knowledge-bases-detail/:id',
        component: KnowledgeBasesDetailComponent,
        data: {
            functionCode: 'CONTENT_KNOWLEDGEBASE'
        },
    },
    {
        path: 'categories',
        component: CategoriesComponent,
        data: {
            functionCode: 'CONTENT_CATEGORY'
        },
    },
    {
        path: 'knowledge-bases/:knowledgeBaseId/comments',
        component: CommentsComponent,
        data: {
            functionCode: 'CONTENT_COMMENT'
        },
    },
    {
        path: 'knowledge-bases/comments',
        component: CommentsComponent,
        data: {
            functionCode: 'CONTENT_COMMENT'
        },
    },
    {
        path: 'knowledge-bases/:knowledgeBaseId/reports',
        component: ReportsComponent,
        data: {
            functionCode: 'CONTENT_REPORT'
        },
    },
    {
        path: 'knowledge-bases/reports',
        component: ReportsComponent,
        data: {
            functionCode: 'CONTENT_REPORT'
        },
    }
]
@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})
export class ContentsRoutingModule { }