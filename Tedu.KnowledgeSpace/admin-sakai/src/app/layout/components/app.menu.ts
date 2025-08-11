import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';

import { RouterModule } from '@angular/router';
import { AppFunction } from '@app/shared/models/function.model';
import { AppMenuItem } from './app.menu-item';
import { animate, state, style, transition, trigger } from '@angular/animations';

@Component({
  selector: 'app-menu',
  imports: [CommonModule, RouterModule, AppMenuItem],
  template: `
    <ul class="layout-menu">
      <ng-container *ngFor="let item of functions; let i = index">
        <li app-menuitem [item]="item" [index]="i" [root]="true"></li>
      </ng-container>
    </ul>
  `
})
export class AppMenu implements OnInit {
  functions: AppFunction[] = [
    {
      id: 'CONTENT',
      name: 'Nội dung',
      url: '/contents',
      sortOrder: 0,
      parentId: null,
      icon: 'pi pi-home',
      children: [
        {
          id: 'CONTENT_CATEGORY',
          name: 'Danh mục',
          url: '/contents/categories',
          sortOrder: 0,
          parentId: 'CONTENT',
          icon: 'pi pi-plus',
          children: [
            {
              id: 'CONTENT_CATEGORY_CREATE',
              name: 'Tạo mới',
              url: '/contents/categories/create',
              sortOrder: 0,
              parentId: 'CONTENT_CATEGORY',
              icon: 'pi pi-heart'
            },
            {
              id: 'CONTENT_CATEGORY_EDIT',
              name: 'Chỉnh sửa',
              url: '/contents/categories/edit',
              sortOrder: 1,
              parentId: 'CONTENT_CATEGORY',
              icon: 'pi pi-heart'
            }
          ]
        },
        {
          id: 'CONTENT_KNOWLEDGEBASE',
          name: 'Bài viết',
          url: '/contents/knowledge-bases',
          sortOrder: 2,
          parentId: 'CONTENT',
          icon: 'fa-edit'
        },
        {
          id: 'CONTENT_COMMENT',
          name: 'Trang',
          url: '/contents/knowledge-bases/comments',
          sortOrder: 3,
          parentId: 'CONTENT',
          icon: 'fa-edit'
        },
        {
          id: 'CONTENT_REPORT',
          name: 'Báo xấu',
          url: '/contents/knowledge-bases/reports',
          sortOrder: 3,
          parentId: 'CONTENT',
          icon: 'fa-edit'
        }
      ]
    },
    {
      id: 'STATISTIC',
      name: 'Thống kê',
      url: '/statistics',
      sortOrder: 0,
      parentId: null,
      icon: 'pi pi-home',
      children: [
        {
          id: 'STATISTIC_MONTHLY_NEWMEMBER',
          name: 'Đăng ký từng tháng',
          url: '/statistics/monthly-registers',
          sortOrder: 1,
          parentId: 'STATISTIC',
          icon: 'fa-wrench'
        },
        {
          id: 'STATISTIC_MONTHLY_NEWKB',
          name: 'Bài đăng hàng tháng',
          url: '/statistics/monthly-newkbs',
          sortOrder: 2,
          parentId: 'STATISTIC',
          icon: 'fa-wrench'
        },
        {
          id: 'STATISTIC_MONTHLY_COMMENT',
          name: 'Comment theo tháng',
          url: '/statistics/monthly-comments',
          sortOrder: 3,
          parentId: 'STATISTIC',
          icon: 'fa-wrench'
        }
      ]
    },
    {
      id: 'SYSTEM',
      name: 'Hệ thống',
      url: '/systems',
      sortOrder: 0,
      parentId: null,
      icon: 'pi pi-home',
      children: [
        {
          id: 'SYSTEM_FUNCTION',
          name: 'Chức năng',
          url: '/systems/functions',
          sortOrder: 0,
          parentId: 'SYSTEM',
          icon: 'fa-desktop'
        },
        {
          id: 'SYSTEM_PERMISSION',
          name: 'Quyền hạn',
          url: '/systems/permissions',
          sortOrder: 0,
          parentId: 'SYSTEM',
          icon: 'fa-desktop'
        },
        {
          id: 'SYSTEM_ROLE',
          name: 'Nhóm quyền',
          url: '/systems/roles',
          sortOrder: 0,
          parentId: 'SYSTEM',
          icon: 'fa-desktop'
        },
        {
          id: 'SYSTEM_USER',
          name: 'Người dùng',
          url: '/systems/users',
          sortOrder: 0,
          parentId: 'SYSTEM',
          icon: 'fa-desktop'
        }
      ]
    },
    {
      id: 'DASHBOARD',
      name: 'Bảng điều khiển',
      url: '/dashboard',
      sortOrder: 1,
      parentId: null,
      icon: 'pi pi-home'
    }
  ];
  active = false;
  constructor() {}

  model: AppFunction[] = [
    {
      id: 'ROOT',
      name: 'Knowledge Base',
      url: '',
      sortOrder: 0,
      parentId: null,
      icon: 'pi pi-fw pi-home'
    }
  ];
  get submenuAnimation() {
    return this.active ? 'expanded' : 'collapsed';
  }
  ngOnInit() {
    this.model = this.model.map((item) => ({ ...item, children: this.functions }));
    console.log(this.functions);

    console.log('AppMenu model:', this.model);

    // this.model = [
    //   {
    //     id: 'CONTENT',
    //     name: 'Nội dung',
    //     url: '/contents',
    //     sortOrder: 0,
    //     parentId: null,
    //     icon: 'pi pi-fw pi-home',
    //     children: [
    //       {
    //         id: 'CONTENT_CATEGORY',
    //         name: 'Danh mục',
    //         url: '/contents/categories',
    //         sortOrder: 0,
    //         parentId: 'CONTENT',
    //         icon: null
    //       },
    //       {
    //         id: 'CONTENT_KNOWLEDGEBASE',
    //         name: 'Bài viết',
    //         url: '/contents/knowledge-bases',
    //         sortOrder: 2,
    //         parentId: 'CONTENT',
    //         icon: 'fa-edit'
    //       },
    //       {
    //         id: 'CONTENT_COMMENT',
    //         name: 'Trang',
    //         url: '/contents/knowledge-bases/comments',
    //         sortOrder: 3,
    //         parentId: 'CONTENT',
    //         icon: 'fa-edit'
    //       },
    //       {
    //         id: 'CONTENT_REPORT',
    //         name: 'Báo xấu',
    //         url: '/contents/knowledge-bases/reports',
    //         sortOrder: 3,
    //         parentId: 'CONTENT',
    //         icon: 'fa-edit'
    //       }
    //     ]
    //   },
    //   {
    //     id: 'STATISTIC',
    //     name: 'Thống kê',
    //     url: '/statistics',
    //     sortOrder: 0,
    //     parentId: null,
    //     icon: 'fa-bar-chart-o',
    //     children: [
    //       {
    //         id: 'STATISTIC_MONTHLY_NEWMEMBER',
    //         name: 'Đăng ký từng tháng',
    //         url: '/statistics/monthly-registers',
    //         sortOrder: 1,
    //         parentId: 'STATISTIC',
    //         icon: 'fa-wrench'
    //       },
    //       {
    //         id: 'STATISTIC_MONTHLY_NEWKB',
    //         name: 'Bài đăng hàng tháng',
    //         url: '/statistics/monthly-newkbs',
    //         sortOrder: 2,
    //         parentId: 'STATISTIC',
    //         icon: 'fa-wrench'
    //       },
    //       {
    //         id: 'STATISTIC_MONTHLY_COMMENT',
    //         name: 'Comment theo tháng',
    //         url: '/statistics/monthly-comments',
    //         sortOrder: 3,
    //         parentId: 'STATISTIC',
    //         icon: 'fa-wrench'
    //       }
    //     ]
    //   },
    //   {
    //     id: 'SYSTEM',
    //     name: 'Hệ thống',
    //     url: '/systems',
    //     sortOrder: 0,
    //     parentId: null,
    //     icon: 'fa-th-list',
    //     children: [
    //       {
    //         id: 'SYSTEM_FUNCTION',
    //         name: 'Chức năng',
    //         url: '/systems/functions',
    //         sortOrder: 0,
    //         parentId: 'SYSTEM',
    //         icon: 'fa-desktop'
    //       },
    //       {
    //         id: 'SYSTEM_PERMISSION',
    //         name: 'Quyền hạn',
    //         url: '/systems/permissions',
    //         sortOrder: 0,
    //         parentId: 'SYSTEM',
    //         icon: 'fa-desktop'
    //       },
    //       {
    //         id: 'SYSTEM_ROLE',
    //         name: 'Nhóm quyền',
    //         url: '/systems/roles',
    //         sortOrder: 0,
    //         parentId: 'SYSTEM',
    //         icon: 'fa-desktop'
    //       },
    //       {
    //         id: 'SYSTEM_USER',
    //         name: 'Người dùng',
    //         url: '/systems/users',
    //         sortOrder: 0,
    //         parentId: 'SYSTEM',
    //         icon: 'fa-desktop'
    //       }
    //     ]
    //   },
    //   {
    //     id: 'DASHBOARD',
    //     name: 'Bảng điều khiển',
    //     url: '/dashboard',
    //     sortOrder: 1,
    //     parentId: null,
    //     icon: 'fa-dashboard',
    //     children: []
    //   }
    // ];
    // this.model = [
    //   {
    //     label: 'Home',
    //     items: [{ label: 'Dashboard', icon: 'pi pi-fw pi-home', routerLink: ['/'] }]
    //   },
    //   {
    //     label: 'UI Components',
    //     items: [
    //       { label: 'Form Layout', icon: 'pi pi-fw pi-id-card', routerLink: ['/uikit/formlayout'] },
    //       { label: 'Input', icon: 'pi pi-fw pi-check-square', routerLink: ['/uikit/input'] },
    //       { label: 'Button', icon: 'pi pi-fw pi-mobile', class: 'rotated-icon', routerLink: ['/uikit/button'] },
    //       { label: 'Table', icon: 'pi pi-fw pi-table', routerLink: ['/uikit/table'] },
    //       { label: 'List', icon: 'pi pi-fw pi-list', routerLink: ['/uikit/list'] },
    //       { label: 'Tree', icon: 'pi pi-fw pi-share-alt', routerLink: ['/uikit/tree'] },
    //       { label: 'Panel', icon: 'pi pi-fw pi-tablet', routerLink: ['/uikit/panel'] },
    //       { label: 'Overlay', icon: 'pi pi-fw pi-clone', routerLink: ['/uikit/overlay'] },
    //       { label: 'Media', icon: 'pi pi-fw pi-image', routerLink: ['/uikit/media'] },
    //       { label: 'Menu', icon: 'pi pi-fw pi-bars', routerLink: ['/uikit/menu'] },
    //       { label: 'Message', icon: 'pi pi-fw pi-comment', routerLink: ['/uikit/message'] },
    //       { label: 'File', icon: 'pi pi-fw pi-file', routerLink: ['/uikit/file'] },
    //       { label: 'Chart', icon: 'pi pi-fw pi-chart-bar', routerLink: ['/uikit/charts'] },
    //       { label: 'Timeline', icon: 'pi pi-fw pi-calendar', routerLink: ['/uikit/timeline'] },
    //       { label: 'Misc', icon: 'pi pi-fw pi-circle', routerLink: ['/uikit/misc'] }
    //     ]
    //   },
    //   {
    //     label: 'Pages',
    //     icon: 'pi pi-fw pi-briefcase',
    //     routerLink: ['/pages'],
    //     items: [
    //       {
    //         label: 'Landing',
    //         icon: 'pi pi-fw pi-globe',
    //         routerLink: ['/landing']
    //       },
    //       {
    //         label: 'Auth',
    //         icon: 'pi pi-fw pi-user',
    //         items: [
    //           {
    //             label: 'Login',
    //             icon: 'pi pi-fw pi-sign-in',
    //             routerLink: ['/auth/login']
    //           },
    //           {
    //             label: 'Error',
    //             icon: 'pi pi-fw pi-times-circle',
    //             routerLink: ['/auth/error']
    //           },
    //           {
    //             label: 'Access Denied',
    //             icon: 'pi pi-fw pi-lock',
    //             routerLink: ['/auth/access']
    //           }
    //         ]
    //       },
    //       {
    //         label: 'Crud',
    //         icon: 'pi pi-fw pi-pencil',
    //         routerLink: ['/pages/crud']
    //       },
    //       {
    //         label: 'Not Found',
    //         icon: 'pi pi-fw pi-exclamation-circle',
    //         routerLink: ['/pages/notfound']
    //       },
    //       {
    //         label: 'Empty',
    //         icon: 'pi pi-fw pi-circle-off',
    //         routerLink: ['/pages/empty']
    //       }
    //     ]
    //   },
    //   {
    //     label: 'Hierarchy',
    //     items: [
    //       {
    //         label: 'Submenu 1',
    //         icon: 'pi pi-fw pi-bookmark',
    //         items: [
    //           {
    //             label: 'Submenu 1.1',
    //             icon: 'pi pi-fw pi-bookmark',
    //             items: [
    //               { label: 'Submenu 1.1.1', icon: 'pi pi-fw pi-bookmark' },
    //               { label: 'Submenu 1.1.2', icon: 'pi pi-fw pi-bookmark' },
    //               { label: 'Submenu 1.1.3', icon: 'pi pi-fw pi-bookmark' }
    //             ]
    //           },
    //           {
    //             label: 'Submenu 1.2',
    //             icon: 'pi pi-fw pi-bookmark',
    //             items: [{ label: 'Submenu 1.2.1', icon: 'pi pi-fw pi-bookmark' }]
    //           }
    //         ]
    //       },
    //       {
    //         label: 'Submenu 2',
    //         icon: 'pi pi-fw pi-bookmark',
    //         items: [
    //           {
    //             label: 'Submenu 2.1',
    //             icon: 'pi pi-fw pi-bookmark',
    //             items: [
    //               { label: 'Submenu 2.1.1', icon: 'pi pi-fw pi-bookmark' },
    //               { label: 'Submenu 2.1.2', icon: 'pi pi-fw pi-bookmark' }
    //             ]
    //           },
    //           {
    //             label: 'Submenu 2.2',
    //             icon: 'pi pi-fw pi-bookmark',
    //             items: [{ label: 'Submenu 2.2.1', icon: 'pi pi-fw pi-bookmark' }]
    //           }
    //         ]
    //       }
    //     ]
    //   },
    //   {
    //     label: 'Get Started',
    //     items: [
    //       {
    //         label: 'Documentation',
    //         icon: 'pi pi-fw pi-book',
    //         routerLink: ['/documentation']
    //       },
    //       {
    //         label: 'View Source',
    //         icon: 'pi pi-fw pi-github',
    //         url: 'https://github.com/primefaces/sakai-ng',
    //         target: '_blank'
    //       }
    //     ]
    //   }
    // ];
  }
}
