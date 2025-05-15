import { Component } from '@angular/core';

@Component({
  standalone: false,
  selector: 'sb-auth-callback',
  templateUrl: './auth-callback.component.html',
  styleUrl: './auth-callback.component.scss'
})
export class AuthCallbackComponent {
  error: boolean = true;
}
