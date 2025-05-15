import { Component } from '@angular/core';

@Component({
  standalone: false,
  selector: 'sb-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrl: './sidebar.component.scss'
})
export class SidebarComponent {
  isActive: boolean = true;
  collapsed: boolean;
  showMenu: string;
  pushRightClass: string;

  eventCalled() {
    this.isActive = !this.isActive;
  }

  addExpandClass(element: any) {

  }

  toggleCollapsed() {

  }

  isToggled(): boolean {
    return true;
  }

  toggleSidebar() {

  }

  rltAndLtr() {

  }

  changeLang(language: string) {

  }

  onLoggedout() {
  }
}
