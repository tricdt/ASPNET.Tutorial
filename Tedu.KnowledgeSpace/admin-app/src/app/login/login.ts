import { Component } from '@angular/core';
import { routerTransition } from '@app/router.animations';
import { ButtonModule } from 'primeng/button';
import { AuthService } from '@app/shared/services';
import { NgxSpinnerService } from 'ngx-spinner';
@Component({
  selector: 'app-login',
  imports: [ButtonModule],
  templateUrl: './login.html',
  styleUrl: './login.scss',
  animations: [routerTransition()],
})
export class Login {
  constructor(
    private spinner: NgxSpinnerService,
    private authService: AuthService
  ) {}
  login() {
    this.spinner.show();
    this.authService.login();
  }
}
