import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from '@app/shared/services/auth.service';

@Component({
  selector: 'app-auth-callback',
  template: `
    <h1>Authentication Callback</h1>
    <p>Processing authentication callback...</p>
  `
})
export class AuthCallback implements OnInit {
  error: boolean;
  constructor(
    private authService: AuthService,
    private router: Router,
    private route: ActivatedRoute
  ) {}

  async ngOnInit() {
    // check for error
    if (this.route.snapshot.queryParams['error']) {
      this.error = true;
      return;
    }

    await this.authService.completeAuthentication();
    this.router.navigate(['/']);
  }
}
