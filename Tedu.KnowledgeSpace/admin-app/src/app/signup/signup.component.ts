import { Component } from '@angular/core';
import { routerTransition } from '@app/router.animations';

@Component({
  standalone: false,
  selector: 'sb-signup',
  templateUrl: './signup.component.html',
  styleUrl: './signup.component.scss',
  animations: [routerTransition()]
})
export class SignupComponent {

}
