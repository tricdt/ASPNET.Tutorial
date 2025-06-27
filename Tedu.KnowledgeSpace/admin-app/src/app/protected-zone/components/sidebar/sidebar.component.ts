import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService, UsersService } from '@app/shared/services';
import { Function } from '@app/shared/models/function.model';
@Component({
  standalone: false,
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrl: './sidebar.component.scss'
})
export class SidebarComponent implements OnInit {
  isActive: boolean = true;
  collapsed: boolean;
  showMenu: string;
  pushRightClass: string;
  functions: Function[];
  @Output() collapsedEvent = new EventEmitter<boolean>();
  constructor(
    private router: Router,
    private userService: UsersService,
    private authService: AuthService
  ) {
    this.loadMenu();
  }
  loadMenu() {
    const profile = this.authService.profile;
    this.userService.getMenuByUser(profile.sub).subscribe((response: Function[]) => {
      this.functions = response;
      console.log('Functions loaded:', this.functions);
      localStorage.setItem('functions', JSON.stringify(response));
    });
  }

  ngOnInit(): void {}

  eventCalled() {
    this.isActive = !this.isActive;
  }

  addExpandClass(element: any) {
    if (element === this.showMenu) {
      this.showMenu = '0';
    } else {
      this.showMenu = element;
    }
  }

  toggleCollapsed() {
    this.collapsed = !this.collapsed;
    this.collapsedEvent.emit(this.collapsed);
  }

  isToggled(): boolean {
    return true;
  }

  toggleSidebar() {}

  rltAndLtr() {}

  changeLang(language: string) {}

  onLoggedout() {}
}
