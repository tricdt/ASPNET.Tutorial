import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-empty',
  template: ` <h1>EMPTY</h1> `,
})
export class Empty implements OnInit {
  constructor() {}

  ngOnInit() {}
}
