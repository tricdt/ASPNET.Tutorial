import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-stat',
  imports: [],
  templateUrl: './stat.html',
  styleUrl: './stat.scss',
})
export class Stat {
  @Input() bgClass: string;
  @Input() icon: string;
  @Input() count: number;
  @Input() label: string;
  @Input() data: number;
  @Output() event: EventEmitter<any> = new EventEmitter();
  constructor() {}

  ngOnInit() {}
}
