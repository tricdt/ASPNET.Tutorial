import { Component, inject } from '@angular/core';
import { Router } from '@angular/router';
import { Auth } from '@app/shared/services/auth';

@Component({
  selector: 'app-auth-callback',
  imports: [],
  template: ` <p>Login successful! Redirecting...</p>`,
  styles: ``,
})
export class AuthCallback {
  private authService = inject(Auth);
  private router = inject(Router);

  async ngOnInit() {
    await this.authService.signinCallback().then(() => {
      this.router.navigate([
        this.authService.getAuthGuardInterceptedPathname(),
      ]);
    });
  }
}
