import { Component, inject, Renderer2 } from '@angular/core';
import { AppFunction } from '@app/shared/models/function.model';
import { AuthService } from '@app/shared/services/auth';
import { UsersService } from '@app/shared/services/user';
import { ButtonModule } from 'primeng/button';
import { filter, map, Subscription } from 'rxjs';
import { CommonModule } from '@angular/common';
import { NavigationEnd, Router, RouterModule } from '@angular/router';
import { LayoutService } from '@app/shared/services/layout';
import { Topbar } from '@app/protected-zone/components/topbar/topbar';
import { Footer } from '@app/protected-zone/components/footer/footer';
import { Sidebar } from './sidebar/sidebar';
@Component({
  selector: 'app-pages-layout',
  imports: [ButtonModule, Topbar, CommonModule, Sidebar, RouterModule, Footer],
  template: ` <div class="layout-wrapper" [ngClass]="containerClass">
      <app-topbar />
      <app-sidebar />
      <div class="layout-main-container">
        <div class="layout-main">
          <router-outlet></router-outlet>
        </div>
      </div>
      <app-footer />
    </div>
    <div class="layout-mask animate-fadein"></div>`,
  styles: ``,
})
export class PagesLayout {
  private userService: UsersService = inject(UsersService);
  private authService: AuthService = inject(AuthService);
  private layoutService: LayoutService = inject(LayoutService);
  private router: Router = inject(Router);
  private renderer: Renderer2 = inject(Renderer2);
  overlayMenuOpenSubscription: Subscription;
  menuOutsideClickListener: any;

  constructor() {
    this.overlayMenuOpenSubscription =
      this.layoutService.overlayOpen$.subscribe(() => {
        if (!this.menuOutsideClickListener) {
          this.menuOutsideClickListener = this.renderer.listen(
            'document',
            'click',
            (event) => {
              if (this.isOutsideClicked(event)) {
                this.hideMenu();
              }
            }
          );
        }

        if (this.layoutService.layoutState().staticMenuMobileActive) {
          this.blockBodyScroll();
        }
      });

    this.router.events
      .pipe(filter((event) => event instanceof NavigationEnd))
      .subscribe(() => {
        this.hideMenu();
      });
  }

  isOutsideClicked(event: MouseEvent) {
    const sidebarEl = document.querySelector('.layout-pages-sidebar');
    const topbarEl = document.querySelector('.layout-menu-button');
    const eventTarget = event.target as Node;

    return !(
      sidebarEl?.isSameNode(eventTarget) ||
      sidebarEl?.contains(eventTarget) ||
      topbarEl?.isSameNode(eventTarget) ||
      topbarEl?.contains(eventTarget)
    );
  }

  hideMenu() {
    this.layoutService.layoutState.update((prev) => ({
      ...prev,
      overlayMenuActive: false,
      staticMenuMobileActive: false,
      menuHoverActive: false,
    }));
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
      document.body.className = document.body.className.replace(
        new RegExp(
          '(^|\\b)' + 'blocked-scroll'.split(' ').join('|') + '(\\b|$)',
          'gi'
        ),
        ' '
      );
    }
  }

  get containerClass() {
    return {
      'layout-overlay':
        this.layoutService.layoutConfig().menuMode === 'overlay',
      'layout-static': this.layoutService.layoutConfig().menuMode === 'static',
      'layout-static-inactive':
        this.layoutService.layoutState().staticMenuDesktopInactive &&
        this.layoutService.layoutConfig().menuMode === 'static',
      'layout-overlay-active':
        this.layoutService.layoutState().overlayMenuActive,
      'layout-mobile-active':
        this.layoutService.layoutState().staticMenuMobileActive,
    };
  }
}
