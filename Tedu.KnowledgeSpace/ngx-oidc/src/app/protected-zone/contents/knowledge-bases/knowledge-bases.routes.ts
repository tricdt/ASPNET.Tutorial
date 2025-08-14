import { Routes } from '@angular/router';
import { Comments } from './comments/comments';
import { KnowledgeBases } from './knowledge-bases';
import { Reports } from './reports/reports';

export default [
  {
    path: '',
    component: KnowledgeBases
  },
  {
    path: 'comments',
    component: Comments
  },
  {
    path: 'reports',
    component: Reports
  }
] as Routes;
