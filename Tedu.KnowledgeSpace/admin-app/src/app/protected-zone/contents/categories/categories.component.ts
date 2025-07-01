import { Component, OnDestroy, OnInit } from '@angular/core';
import { BaseComponent } from '@app/protected-zone/base/base.component';
import { Subscription } from 'rxjs';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { CategoriesService } from '@app/shared/services';
import { Category, Pagination } from '@app/shared/models';
@Component({
  selector: 'app-categories',
  standalone: false,
  templateUrl: './categories.component.html',
  styleUrl: './categories.component.scss'
})
export class CategoriesComponent extends BaseComponent implements OnInit, OnDestroy {
  private subscription = new Subscription();
  public screenTitle: string;
  // Default
  public bsModalRef: BsModalRef;
  public blockedPanel = false;
  /**
   * Paging
   */
  public pageIndex = 1;
  public pageSize = 10;
  public pageDisplay = 10;
  public totalRecords: number;
  public keyword = '';
  // Role
  public items: any[];
  public selectedItems = [];
  constructor(private categoriesService: CategoriesService) {
    super('CONTENT_CATEGORY');
  }

  ngOnInit(): void {
    super.ngOnInit();
    this.loadData();
  }
  loadData(selectedId = null) {
    this.blockedPanel = true;
    this.subscription.add(
      this.categoriesService.getAllPaging(this.keyword, this.pageIndex, this.pageSize).subscribe(
        (response: Pagination<Category>) => {
          this.processLoadData(selectedId, response);
          setTimeout(() => {
            this.blockedPanel = false;
          }, 1000);
        },
        (error) => {
          setTimeout(() => {
            this.blockedPanel = false;
          }, 1000);
        }
      )
    );
  }
  processLoadData(selectedId = null, response: Pagination<Category>) {
    this.items = response.items;
    this.pageIndex = this.pageIndex;
    this.pageSize = this.pageSize;
    this.totalRecords = response.totalRecords;
    if (this.selectedItems.length === 0 && this.items.length > 0) {
      this.selectedItems.push(this.items[0]);
    }
    if (selectedId != null && this.items.length > 0) {
      this.selectedItems = this.items.filter((x) => x.Id === selectedId);
    }
  }

  ngOnDestroy(): void {}
}
