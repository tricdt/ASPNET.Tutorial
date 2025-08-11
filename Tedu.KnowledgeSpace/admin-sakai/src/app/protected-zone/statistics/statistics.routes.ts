import { Routes } from '@angular/router';
import { MonthlyNewComments } from './monthly-new-comments/monthly-new-comments';
import { MonthlyNewKbs } from './monthly-new-kbs/monthly-new-kbs';
import { MonthlyNewMembers } from './monthly-new-members/monthly-new-members';

export default [
  {
    path: 'monthly-newkbs',
    component: MonthlyNewKbs
  },
  {
    path: 'monthly-registers',
    component: MonthlyNewMembers
  },
  {
    path: 'monthly-comments',
    component: MonthlyNewComments
  }
] as Routes;
