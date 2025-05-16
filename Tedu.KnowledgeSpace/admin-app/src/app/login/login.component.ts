import { Component, OnInit } from '@angular/core';
import { routerTransition } from '@app/router.animations';
import { AuthService } from '@app/shared/services';
import { NgxSpinnerService } from 'ngx-spinner';

@Component({
  standalone: false,
  selector: 'sb-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss',
  animations: [routerTransition()],
})
export class LoginComponent{
  constructor(
    private spinner: NgxSpinnerService,
    private authService: AuthService
  ) { }
  login() {
    this.spinner.show();
    this.authService.login();
  }
}
