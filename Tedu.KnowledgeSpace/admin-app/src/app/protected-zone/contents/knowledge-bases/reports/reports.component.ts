import { Component, OnDestroy, OnInit } from '@angular/core';
import { BaseComponent } from '@app/protected-zone/base/base.component';

@Component({
  selector: 'sb-reports',
  standalone: false,
  templateUrl: './reports.component.html',
  styleUrl: './reports.component.scss'
})
export class ReportsComponent extends BaseComponent implements OnInit, OnDestroy {
  constructor() {
    super('CONTENT_REPORT');
  }
  ngOnDestroy(): void {}
}
