import { Component, OnDestroy, OnInit } from '@angular/core';
import { BaseComponent } from '@app/protected-zone/base/base.component';

@Component({
  selector: 'sb-knowledge-bases',
  standalone: false,
  templateUrl: './knowledge-bases.component.html',
  styleUrl: './knowledge-bases.component.scss'
})
export class KnowledgeBasesComponent extends BaseComponent implements OnInit, OnDestroy {
  constructor() {
    super('CONTENT_KNOWLEDGEBASE');
  }
  ngOnDestroy(): void {
  }


}
