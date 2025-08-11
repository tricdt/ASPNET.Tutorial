import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { ButtonModule } from 'primeng/button';
@Component({
  selector: 'app-root',
  imports: [RouterOutlet, ButtonModule],
  template: `<router-outlet></router-outlet>`,
  styleUrl: './app.scss'
})
export class App {
  protected readonly title = signal('sakai');
}
