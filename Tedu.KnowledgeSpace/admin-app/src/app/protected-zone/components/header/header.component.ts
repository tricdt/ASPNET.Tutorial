import { Component } from '@angular/core';

@Component({
  standalone: false,
  selector: 'sb-header',
  templateUrl: './header.component.html',
  styleUrl: './header.component.scss'
})
export class HeaderComponent {
  ngOnInit() {
  }

  isToggled(): boolean {
    return false;
  }

  toggleSidebar() {

  }

  rltAndLtr() {

  }

  onLoggedout() {
  }

  changeLang(language: string) {
  }
  signout(){}
}
