import { Component, inject } from '@angular/core';
import { AuthService } from '@app/shared/services/auth';
import { UsersService } from '@app/shared/services/user';
import { ButtonModule } from 'primeng/button';
import { map } from 'rxjs';
@Component({
  selector: 'app-layout',
  imports: [ButtonModule],
  template: ` <p-button label="Submit" class="dark:bg-surface-900" />`,
  styles: ``,
})
export class Layout {
  private userService: UsersService = inject(UsersService);
  // private authService: AuthService = inject(AuthService);
  constructor() {
    //this.loadMenu();
  }
  // loadMenu() {
  //   const profile = this.authService.getUser().pipe(
  //     map((response) => {
  //       console.log(response);
  //     })
  //   );
  // }
}
