import { CommonModule } from '@angular/common';
import { Component, computed, inject, input, OnInit } from '@angular/core';
import { ButtonModule } from 'primeng/button';
import { AppConfiguration } from './app.configurator';
import { LayoutService } from '../service/layout.service';
import { StyleClassModule } from 'primeng/styleclass';

@Component({
  imports: [CommonModule, ButtonModule, AppConfiguration, StyleClassModule],
  selector: 'app-floating-configurator',
  template: `
    <div class="flex gap-4 top-8 right-8" [ngClass]="{ fixed: float() }">
      <p-button type="button" (onClick)="toggleDarkMode()" [rounded]="true" [icon]="isDarkTheme() ? 'pi pi-moon' : 'pi pi-sun'" severity="secondary" />
      <div class="relative">
        <p-button icon="pi pi-palette" pStyleClass="@next" enterFromClass="hidden" enterActiveClass="animate-scalein" leaveToClass="hidden" leaveActiveClass="animate-fadeout" [hideOnOutsideClick]="true" type="button" rounded />
        <app-configurator />
      </div>
    </div>
  `
})
export class AppFloatingConfigurator implements OnInit {
  LayoutService = inject(LayoutService);
  float = input<boolean>(true);
  isDarkTheme = computed(() => this.LayoutService.layoutConfig().darkTheme);
  constructor() {}
  toggleDarkMode() {
    this.LayoutService.layoutConfig.update((state) => ({ ...state, darkTheme: !state.darkTheme }));
  }
  ngOnInit() {}
}
// <button type="button" class="layout-topbar-action" (click)="toggleDarkMode()">
//   <i [ngClass]="{ 'pi ': true, 'pi-moon': layoutService.isDarkTheme(), 'pi-sun': !layoutService.isDarkTheme() }"></i>
// </button>
