import { Component, OnInit, Renderer2 } from '@angular/core';
import { AppFooter } from './app.footer';
import { AppTopbar } from './app.topbar';
import { AppSidebar } from './app.sidebar';
import { RouterOutlet } from '@angular/router';
import { CommonModule } from '@angular/common';
import { LayoutService } from '../service/layout.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-layout',
  template: `
    <div class="layout-wrapper" [ngClass]="containerClass">
      <app-topbar />
      <app-sidebar />
      <div class="layout-main-container">
        <div class="layout-main">
          <router-outlet></router-outlet>
        </div>
      </div>
      <app-footer />
    </div>
  `,
  imports: [CommonModule, AppFooter, AppTopbar, AppSidebar, RouterOutlet]
})
export class AppLayout implements OnInit {
  overlayMenuOpenSubscription: Subscription;
  menuOutsideClickListener: any;
  constructor(
    public layoutService: LayoutService,
    public renderer: Renderer2
  ) {
    this.overlayMenuOpenSubscription = this.layoutService.overlayOpen$.subscribe(() => {
      if (!this.menuOutsideClickListener) {
        this.menuOutsideClickListener = this.renderer.listen('document', 'click', (event) => {
          if (this.isOutsideClicked(event)) {
            this.hideMenu();
          }
        });
      }

      if (this.layoutService.layoutState().staticMenuMobileActive) {
        this.blockBodyScroll();
      }
    });
  }

  isOutsideClicked(event: MouseEvent) {
    const sidebarEl = document.querySelector('.layout-sidebar');
    const topbarEl = document.querySelector('.layout-menu-button');
    const eventTarget = event.target as Node;

    return !(sidebarEl?.isSameNode(eventTarget) || sidebarEl?.contains(eventTarget) || topbarEl?.isSameNode(eventTarget) || topbarEl?.contains(eventTarget));
  }

  hideMenu() {
    this.layoutService.layoutState.update((prev) => ({ ...prev, overlayMenuActive: false, staticMenuMobileActive: false, menuHoverActive: false }));
    if (this.menuOutsideClickListener) {
      this.menuOutsideClickListener();
      this.menuOutsideClickListener = null;
    }
    this.unblockBodyScroll();
  }

  blockBodyScroll(): void {
    if (document.body.classList) {
      document.body.classList.add('blocked-scroll');
    } else {
      document.body.className += ' blocked-scroll';
    }
  }

  unblockBodyScroll(): void {
    if (document.body.classList) {
      document.body.classList.remove('blocked-scroll');
    } else {
      document.body.className = document.body.className.replace(new RegExp('(^|\\b)' + 'blocked-scroll'.split(' ').join('|') + '(\\b|$)', 'gi'), ' ');
    }
  }

  ngOnInit() {}

  get containerClass() {
    return {
      'layout-overlay': this.layoutService.layoutConfig().menuMode === 'overlay',
      'layout-static': this.layoutService.layoutConfig().menuMode === 'static',
      'layout-static-inactive': this.layoutService.layoutState().staticMenuDesktopInactive && this.layoutService.layoutConfig().menuMode === 'static',
      'layout-overlay-active': this.layoutService.layoutState().overlayMenuActive,
      'layout-mobile-active': this.layoutService.layoutState().staticMenuMobileActive
    };
  }
}
