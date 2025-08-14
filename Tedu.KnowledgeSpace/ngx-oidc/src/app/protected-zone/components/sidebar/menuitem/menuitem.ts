import { CommonModule } from '@angular/common';
import { Component, HostBinding, Input, OnInit } from '@angular/core';
import { RouterModule } from '@angular/router';
import { AppFunction } from '@app/shared/models/function.model';
import {
  animate,
  state,
  style,
  transition,
  trigger,
} from '@angular/animations';
@Component({
  selector: '[app-menuitem]',
  imports: [CommonModule, RouterModule],
  template: `
    <ng-container>
      <a
        *ngIf="root && item.children.length > 0"
        class="layout-menuitem-root-text"
        (click)="itemClick($event)"
      >
        <i [ngClass]="item.icon" class="layout-menuitem-icon"></i>
        <span>{{ item.name }}</span>
        <i class="pi pi-fw pi-angle-down layout-submenu-toggler"></i>
      </a>
      <a
        *ngIf="root && item.children.length == 0"
        class="layout-menuitem-root-text"
        [routerLink]="item.url"
        routerLinkActive="active-route"
        [routerLinkActiveOptions]="{ exact: true }"
      >
        <i [ngClass]="item.icon" class="layout-menuitem-icon"></i>
        <span>{{ item.name }}</span>
      </a>
      <a *ngIf="!root && item.children" (click)="itemClick($event)">
        <i [ngClass]="item.icon" class="layout-menuitem-icon"></i>
        <span>{{ item.name }}</span>
        <i class="pi pi-fw pi-angle-down layout-submenu-toggler"></i>
      </a>
      <a
        *ngIf="!root && !item.children"
        [routerLink]="item.url"
        routerLinkActive="active-route"
        [routerLinkActiveOptions]="{ exact: true }"
      >
        <i [ngClass]="item.icon" class="layout-menuitem-icon"></i>
        <span>{{ item.name }}</span>
      </a>
      <ul *ngIf="item.children" [@children]="submenuAnimation">
        <ng-template ngFor let-child let-i="index" [ngForOf]="item.children">
          <li app-menuitem [item]="child" [index]="i"></li>
        </ng-template>
      </ul>
    </ng-container>
  `,
  styles: ``,
  animations: [
    trigger('children', [
      state(
        'collapsed',
        style({
          height: '0',
        })
      ),
      state(
        'expanded',
        style({
          height: '*',
        })
      ),
      transition(
        'collapsed <=> expanded',
        animate('400ms cubic-bezier(0.86, 0, 0.07, 1)')
      ),
    ]),
  ],
})
export class Menuitem implements OnInit {
  @Input() item!: AppFunction;
  @Input() index!: number;
  @Input() parentKey!: string;
  @Input() @HostBinding('class.layout-root-menuitem') root!: boolean;
  active = false;
  constructor() {}

  @HostBinding('class.active-menuitem')
  get activeClass() {
    return this.active;
  }

  get submenuAnimation() {
    return this.active ? 'expanded' : 'collapsed';
  }
  ngOnInit() {}
  itemClick(event: Event) {
    // toggle active state
    if (this.item.children) {
      this.active = !this.active;
    }
  }
}
