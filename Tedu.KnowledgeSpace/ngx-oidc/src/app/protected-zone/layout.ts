import { Component } from '@angular/core';
import { ButtonModule } from 'primeng/button';
@Component({
  selector: 'app-layout',
  imports: [ButtonModule],
  template: ` <p-button label="Submit" class="dark:bg-surface-900" />`,
  styles: ``,
})
export class Layout {}
