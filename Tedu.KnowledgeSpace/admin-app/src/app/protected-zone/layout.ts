import { Component } from '@angular/core';
import { Header, Sidebar } from './components';
import { RouterOutlet } from '@angular/router';
import { CommonModule } from '@angular/common';
import { TranslateModule } from '@ngx-translate/core';

@Component({
  selector: 'app-layout',
  imports: [TranslateModule, RouterOutlet, Header, Sidebar],
  templateUrl: './layout.html',
  styleUrl: './layout.scss'
})
export class Layout {

}
