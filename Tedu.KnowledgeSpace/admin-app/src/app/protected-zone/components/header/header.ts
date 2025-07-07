import { Component } from '@angular/core';
import { RouterLink } from '@angular/router';
import { TranslateModule, TranslateService } from '@ngx-translate/core';
import { Subscription } from 'rxjs';
import { NgbDropdownModule } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-header',
  imports: [TranslateModule, RouterLink, NgbDropdownModule],
  templateUrl: './header.html',
  styleUrl: './header.scss',
})
export class Header {
  constructor(private translate: TranslateService) {}
  public pushRightClass: string;

  userName: string;
  isAuthenticated: boolean;
  subscription: Subscription;
  changeLang(language: string) {
    this.translate.use(language);
  }
  toggleSidebar() {}
  signout(){}
}
