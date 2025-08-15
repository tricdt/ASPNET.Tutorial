import { Component } from '@angular/core';
import { PagesMenu } from '../menu/menu';

@Component({
  selector: 'app-sidebar',
  imports: [PagesMenu],
  template: `
    <div class="layout-pages-sidebar">
      <app-menu></app-menu>
    </div>
  `,
  styles: ``,
})
export class Sidebar {}
