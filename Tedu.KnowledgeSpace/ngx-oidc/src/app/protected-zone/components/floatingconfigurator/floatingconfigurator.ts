import { CommonModule } from '@angular/common';
import { Component, computed, inject, input } from '@angular/core';
import { ButtonModule } from 'primeng/button';
import { StyleClassModule } from 'primeng/styleclass';
import { Configurator } from '../configurator/configurator';
import { Layout } from '@app/shared/services/layout';
@Component({
  selector: 'app-floatingconfigurator',
  imports: [CommonModule, ButtonModule, StyleClassModule, Configurator],
  template: `
    <div class="flex gap-4 top-8 right-8" [ngClass]="{ fixed: float() }">
      <p-button
        type="button"
        (onClick)="toggleDarkMode()"
        [rounded]="true"
        [icon]="isDarkTheme() ? 'pi pi-moon' : 'pi pi-sun'"
        severity="secondary"
      />
      <div class="relative">
        <p-button
          icon="pi pi-palette"
          pStyleClass="@next"
          enterFromClass="hidden"
          enterActiveClass="animate-scalein"
          leaveToClass="hidden"
          leaveActiveClass="animate-fadeout"
          [hideOnOutsideClick]="true"
          type="button"
          rounded
        />
        <app-configurator />
      </div>
    </div>
  `,
  styles: ``,
})
export class Floatingconfigurator {
  private layoutService = inject(Layout);
  float = input<boolean>(true);
  isDarkTheme = computed(() => true);
  toggleDarkMode() {
    this.layoutService.layoutConfig.update((state) => ({
      ...state,
      darkTheme: !state.darkTheme,
    }));
  }
}
