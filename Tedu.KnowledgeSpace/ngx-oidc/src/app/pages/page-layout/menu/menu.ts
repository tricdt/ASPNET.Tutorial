import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { MenuItem } from 'primeng/api';
import { PagesMenuitem } from '../menuitem/menuitem';

@Component({
  selector: 'app-menu',
  standalone: true,
  imports: [CommonModule, PagesMenuitem, RouterModule],
  template: `<ul class="layout-pages-menu">
    <ng-container *ngFor="let item of model; let i = index">
      <li
        app-menuitem
        *ngIf="!item.separator"
        [item]="item"
        [index]="i"
        [root]="true"
      ></li>
      <li *ngIf="item.separator" class="menu-separator"></li>
    </ng-container>
  </ul> `,
})
export class PagesMenu {
  model: MenuItem[] = [];

  ngOnInit() {
    this.model = [
      {
        label: 'Home',
        items: [
          { label: 'Dashboard', icon: 'pi pi-fw pi-home', routerLink: ['/'] },
        ],
      },
      {
        label: 'UI Components',
        items: [
          {
            label: 'Form Layout',
            icon: 'pi pi-fw pi-id-card',
            routerLink: ['/pages/uikit/formlayout'],
          },
          {
            label: 'Input',
            icon: 'pi pi-fw pi-check-square',
            routerLink: ['/pages/uikit/input'],
          },
          {
            label: 'Button',
            icon: 'pi pi-fw pi-mobile',
            class: 'rotated-icon',
            routerLink: ['/pages/uikit/button'],
          },
          {
            label: 'Table',
            icon: 'pi pi-fw pi-table',
            routerLink: ['/pages/uikit/table'],
          },
          {
            label: 'List',
            icon: 'pi pi-fw pi-list',
            routerLink: ['/pages/uikit/list'],
          },
          {
            label: 'Tree',
            icon: 'pi pi-fw pi-share-alt',
            routerLink: ['/pages/uikit/tree'],
          },
          {
            label: 'Panel',
            icon: 'pi pi-fw pi-tablet',
            routerLink: ['/pages/uikit/panel'],
          },
          {
            label: 'Overlay',
            icon: 'pi pi-fw pi-clone',
            routerLink: ['/pages/uikit/overlay'],
          },
          {
            label: 'Media',
            icon: 'pi pi-fw pi-image',
            routerLink: ['/pages/uikit/media'],
          },
          {
            label: 'Menu',
            icon: 'pi pi-fw pi-bars',
            routerLink: ['/pages/uikit/menu'],
          },
          {
            label: 'Message',
            icon: 'pi pi-fw pi-comment',
            routerLink: ['/pages/uikit/message'],
          },
          {
            label: 'File',
            icon: 'pi pi-fw pi-file',
            routerLink: ['/pages/uikit/file'],
          },
          {
            label: 'Chart',
            icon: 'pi pi-fw pi-chart-bar',
            routerLink: ['/pages/uikit/charts'],
          },
          {
            label: 'Timeline',
            icon: 'pi pi-fw pi-calendar',
            routerLink: ['/pages/uikit/timeline'],
          },
          {
            label: 'Misc',
            icon: 'pi pi-fw pi-circle',
            routerLink: ['/pages/uikit/misc'],
          },
        ],
      },
      {
        label: 'Pages',
        icon: 'pi pi-fw pi-briefcase',
        routerLink: ['/pages'],
        items: [
          {
            label: 'Landing',
            icon: 'pi pi-fw pi-globe',
            routerLink: ['/landing'],
          },
          {
            label: 'Auth',
            icon: 'pi pi-fw pi-user',
            items: [
              {
                label: 'Login',
                icon: 'pi pi-fw pi-sign-in',
                routerLink: ['/pages/auth/login'],
              },
              {
                label: 'Error',
                icon: 'pi pi-fw pi-times-circle',
                routerLink: ['/pages/auth/error'],
              },
              {
                label: 'Access Denied',
                icon: 'pi pi-fw pi-lock',
                routerLink: ['/pages/auth/access'],
              },
            ],
          },
          {
            label: 'Crud',
            icon: 'pi pi-fw pi-pencil',
            routerLink: ['/pages/crud'],
          },
          {
            label: 'Not Found',
            icon: 'pi pi-fw pi-exclamation-circle',
            routerLink: ['/pages/notfound'],
          },
          {
            label: 'Empty',
            icon: 'pi pi-fw pi-circle-off',
            routerLink: ['/pages/empty'],
          },
        ],
      },
      {
        label: 'Hierarchy',
        items: [
          {
            label: 'Submenu 1',
            icon: 'pi pi-fw pi-bookmark',
            items: [
              {
                label: 'Submenu 1.1',
                icon: 'pi pi-fw pi-bookmark',
                items: [
                  { label: 'Submenu 1.1.1', icon: 'pi pi-fw pi-bookmark' },
                  { label: 'Submenu 1.1.2', icon: 'pi pi-fw pi-bookmark' },
                  { label: 'Submenu 1.1.3', icon: 'pi pi-fw pi-bookmark' },
                ],
              },
              {
                label: 'Submenu 1.2',
                icon: 'pi pi-fw pi-bookmark',
                items: [
                  { label: 'Submenu 1.2.1', icon: 'pi pi-fw pi-bookmark' },
                ],
              },
            ],
          },
          {
            label: 'Submenu 2',
            icon: 'pi pi-fw pi-bookmark',
            items: [
              {
                label: 'Submenu 2.1',
                icon: 'pi pi-fw pi-bookmark',
                items: [
                  { label: 'Submenu 2.1.1', icon: 'pi pi-fw pi-bookmark' },
                  { label: 'Submenu 2.1.2', icon: 'pi pi-fw pi-bookmark' },
                ],
              },
              {
                label: 'Submenu 2.2',
                icon: 'pi pi-fw pi-bookmark',
                items: [
                  { label: 'Submenu 2.2.1', icon: 'pi pi-fw pi-bookmark' },
                ],
              },
            ],
          },
        ],
      },
      {
        label: 'Get Started',
        items: [
          {
            label: 'Documentation',
            icon: 'pi pi-fw pi-book',
            routerLink: ['/documentation'],
          },
          {
            label: 'View Source',
            icon: 'pi pi-fw pi-github',
            url: 'https://github.com/primefaces/sakai-ng',
            target: '_blank',
          },
        ],
      },
    ];
  }
}
