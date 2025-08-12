import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';

import { Router, RouterModule } from '@angular/router';
import { AppFunction } from '@app/shared/models/function.model';
import { AppMenuItem } from './app.menu-item';
import { animate, state, style, transition, trigger } from '@angular/animations';
import { UsersService } from '@app/shared/services/user.service';
import { AuthService } from '@app/shared/services/auth.service';

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
  public functions: AppFunction[];
  active = false;
  constructor(
    public router: Router,
    private userService: UsersService,
    private authService: AuthService
  ) {
    this.loadMenu();
  }

  loadMenu() {
    const profile = this.authService.profile;
    this.userService.getMenuByUser(profile.sub).subscribe((response: AppFunction[]) => {
      this.functions = response;
      console.log('Menu functions loaded:', this.functions);
      localStorage.setItem('functions', JSON.stringify(response));
    });
  }
  get submenuAnimation() {
    return this.active ? 'expanded' : 'collapsed';
  }
  ngOnInit() {}
}
