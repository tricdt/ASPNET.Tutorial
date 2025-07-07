import { CommonModule } from '@angular/common';
import { ChangeDetectorRef, Component, EventEmitter, OnInit, Output } from '@angular/core';
import {
  NavigationEnd,
  Router,
  RouterLink,
  RouterModule,
} from '@angular/router';
import { AuthService } from '@app/shared/services';
import { UsersService } from '@app/shared/services/user.service';
import { TranslateModule, TranslateService } from '@ngx-translate/core';
import { AppFunction } from '@app/shared/models/function.model';
@Component({
  selector: 'app-sidebar',
  imports: [CommonModule, TranslateModule, RouterLink, RouterModule],
  templateUrl: './sidebar.html',
  styleUrl: './sidebar.scss',
})
export class Sidebar implements OnInit {
  isActive: boolean;
  collapsed: boolean;
  showMenu: string;
  pushRightClass: string;
  public functions: AppFunction[];

  @Output() collapsedEvent = new EventEmitter<boolean>();

  constructor(
    private translate: TranslateService,
    public router: Router,
    private userService: UsersService,
    private authService: AuthService,
    private cdr: ChangeDetectorRef
  ) {
    this.loadMenu();
    this.router.events.subscribe((val) => {
      if (
        val instanceof NavigationEnd &&
        window.innerWidth <= 992 &&
        this.isToggled()
      ) {
        this.toggleSidebar();
      }
    });
  }

  loadMenu() {
    const profile = this.authService.Profile;
    this.userService
      .getMenuByUser(profile.sub)
      .subscribe((response: AppFunction[]) => {
        this.functions = response;
        localStorage.setItem('functions', JSON.stringify(response));
      });
  }
  ngOnInit() {
    this.isActive = false;
    this.collapsed = false;
    this.showMenu = '';
    this.pushRightClass = 'push-right';
  }

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
    const dom: Element = document.querySelector('body');
    return dom.classList.contains(this.pushRightClass);
  }

  toggleSidebar() {
    const dom: any = document.querySelector('body');
    dom.classList.toggle(this.pushRightClass);
  }

  rltAndLtr() {
    const dom: any = document.querySelector('body');
    dom.classList.toggle('rtl');
  }

  changeLang(language: string) {
    this.translate.use(language);
  }

  onLoggedout() {
    localStorage.removeItem('isLoggedin');
  }
}
