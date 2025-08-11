import { isPlatformBrowser, DOCUMENT } from '@angular/common';
import { computed, effect, Injectable, signal, PLATFORM_ID, inject } from '@angular/core';
import { Subject } from 'rxjs';
export interface layoutConfig {
  preset?: string;
  primary?: string;
  surface?: string | undefined | null;
  darkTheme?: boolean;
  menuMode?: string;
}

interface LayoutState {
  staticMenuDesktopInactive?: boolean;
  overlayMenuActive?: boolean;
  configSidebarVisible?: boolean;
  staticMenuMobileActive?: boolean;
  menuHoverActive?: boolean;
}

interface MenuChangeEvent {
  key: string;
  routeEvent?: boolean;
}
@Injectable({ providedIn: 'root' })
export class LayoutService {
  _config: layoutConfig = {
    preset: 'Aura',
    primary: 'emerald',
    surface: null,
    darkTheme: false,
    menuMode: 'static'
  };

  _state: LayoutState = {
    staticMenuDesktopInactive: false,
    overlayMenuActive: false,
    configSidebarVisible: false,
    staticMenuMobileActive: false,
    menuHoverActive: false
  };

  private readonly STORAGE_KEY = 'appConfigState';

  document = inject(DOCUMENT);

  platformId = inject(PLATFORM_ID);

  layoutConfig = signal<layoutConfig>(null);

  layoutState = signal<LayoutState>(this._state);

  transitionComplete = signal<boolean>(false);

  private overlayOpen = new Subject<any>();

  private menuSource = new Subject<MenuChangeEvent>();

  overlayOpen$ = this.overlayOpen.asObservable();

  menuSource$ = this.menuSource.asObservable();

  isDarkTheme = computed(() => this.layoutConfig().darkTheme);

  isOverlay = computed(() => this.layoutConfig().menuMode === 'overlay');

  private initialized = false;

  constructor() {
    this.layoutConfig.set({ ...this.loadLayoutConfig() });
    effect(() => {
      const config = this.layoutConfig();

      if (!this.initialized || !config) {
        this.initialized = true;
        return;
      }
      this.saveLayoutConfig(config);
      this.handleDarkModeTransition(config);
    });
  }

  private handleDarkModeTransition(config: layoutConfig): void {
    if ((document as any).startViewTransition) {
      this.startViewTransition(config);
    } else {
      this.toggleDarkMode(config);
      this.onTransitionEnd();
    }
  }

  private startViewTransition(config: layoutConfig): void {
    const transition = (document as any).startViewTransition(() => {
      this.toggleDarkMode(config);
    });

    transition.ready
      .then(() => {
        this.onTransitionEnd();
      })
      .catch(() => {});
  }

  private onTransitionEnd() {
    this.transitionComplete.set(true);
    setTimeout(() => {
      this.transitionComplete.set(false);
    });
  }

  toggleDarkMode(config?: layoutConfig): void {
    const _config = config || this.layoutConfig();
    if (_config.darkTheme) {
      document.documentElement.classList.add('app-dark');
    } else {
      document.documentElement.classList.remove('app-dark');
    }
  }

  onMenuToggle() {
    if (this.isOverlay()) {
      this.layoutState.update((prev) => ({ ...prev, overlayMenuActive: !this.layoutState().overlayMenuActive }));

      if (this.layoutState().overlayMenuActive) {
        this.overlayOpen.next(null);
      }
    }

    if (this.isDesktop()) {
      this.layoutState.update((prev) => ({ ...prev, staticMenuDesktopInactive: !this.layoutState().staticMenuDesktopInactive }));
    } else {
      this.layoutState.update((prev) => ({ ...prev, staticMenuMobileActive: !this.layoutState().staticMenuMobileActive }));

      if (this.layoutState().staticMenuMobileActive) {
        this.overlayOpen.next(null);
      }
    }
  }

  isDesktop() {
    return window.innerWidth > 991;
  }

  onMenuStateChange(event: MenuChangeEvent) {
    this.menuSource.next(event);
  }

  private loadLayoutConfig(): any {
    if (isPlatformBrowser(this.platformId)) {
      const storedState = localStorage.getItem(this.STORAGE_KEY);
      if (storedState) {
        return JSON.parse(storedState);
      }
    }
    return {
      preset: 'Aura',
      primary: 'emerald',
      surface: null,
      darkTheme: false,
      menuMode: 'static'
    };
  }

  private saveLayoutConfig(state: any): void {
    if (isPlatformBrowser(this.platformId)) {
      localStorage.setItem(this.STORAGE_KEY, JSON.stringify(state));
    }
  }
}
