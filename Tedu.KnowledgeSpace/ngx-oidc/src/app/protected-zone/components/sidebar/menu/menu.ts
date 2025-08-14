import { CommonModule } from '@angular/common';
import { Component, inject } from '@angular/core';
import { AppFunction } from '@app/shared/models/function.model';
import { AuthService } from '@app/shared/services/auth';
import { UsersService } from '@app/shared/services/user';
import { Menuitem } from '../menuitem/menuitem';

@Component({
  selector: 'app-menu',
  imports: [CommonModule, Menuitem],
  template: ` <ul class="layout-menu">
    <ng-container *ngFor="let item of functions; let i = index">
      <li app-menuitem [item]="item" [index]="i" [root]="true"></li>
    </ng-container>
  </ul>`,
  styles: ``,
})
export class Menu {
  private authService: AuthService = inject(AuthService);
  private userService: UsersService = inject(UsersService);
  public functions: AppFunction[];
  active = false;
  constructor() {
    this.loadMenu();
  }
  loadMenu() {
    const profile = this.authService.user().profile;
    this.userService
      .getMenuByUser(profile.sub)
      .subscribe((response: AppFunction[]) => {
        this.functions = response;
        localStorage.setItem('functions', JSON.stringify(response));
      });
  }
}
