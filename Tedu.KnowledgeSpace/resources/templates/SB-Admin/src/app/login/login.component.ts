import { Component } from '@angular/core';
import { routerTransition } from '@app/router.animations';

@Component({
  standalone: false,
  selector: 'sb-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss',
  animations: [routerTransition()],
})
export class LoginComponent {
  onLoggedin() {

  }
}
