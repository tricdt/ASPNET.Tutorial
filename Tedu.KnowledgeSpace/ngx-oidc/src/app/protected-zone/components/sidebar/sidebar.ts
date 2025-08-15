import { Component } from '@angular/core';
import { Menu } from './menu/menu';
import { Router } from '@angular/router';

@Component({
  selector: 'app-sidebar',
  imports: [Menu],
  template: `
    @if(!router.routerState.snapshot.url.includes('pages')){
    <div class="layout-sidebar">
      <app-menu />
    </div>
    }@else {
    <div class="layout-sidebar"></div>
    }
  `,
  styles: ``,
})
export class Sidebar {
  constructor(public router: Router) {}
}
