import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from '@environments/environment';
import { catchError, map } from 'rxjs';
import { UtilitiesService } from './utilities.service';

@Injectable({ providedIn: 'root' })
export class UsersService extends BaseService {
  private _sharedHeaders = new HttpHeaders();

  constructor(
    private http: HttpClient,
    private utilitiesService: UtilitiesService
  ) {
    super();
    this._sharedHeaders = this._sharedHeaders.set(
      'Content-Type',
      'application/json'
    );
  }
  getMenuByUser(userId: string) {
    return this.http
      .get<Function[]>(`${environment.apiUrl}/api/users/${userId}/menu`, {
        headers: this._sharedHeaders,
      })
      .pipe(
        map((response) => {
          const functions =
            this.utilitiesService.UnflatteringForLeftMenu(response);
          return functions;
        }),
        catchError(this.handleError)
      );
  }
}


    // Trong service của bạn
// async getMenuByUser(userId: string, cdr?: ChangeDetectorRef): Promise<any[]> {
//   const http = inject(HttpClient);
//   const utilitiesService = inject(UtilitiesService);
//   try {
//     // 1. Gọi API bằng Promise thay vì Observable
//     const response = await lastValueFrom(
//       http.get<Function[]>(`${environment.apiUrl}/api/users/${userId}/menu`, {
//         headers: this._sharedHeaders
//       })
//     );
//     // 2. Xử lý dữ liệu
//     const functions = utilitiesService.UnflatteringForLeftMenu(response);
//     // 3. Thông báo thay đổi nếu có ChangeDetectorRef
//     cdr?.detectChanges();
//     return functions;
//   } catch (error) {
//     // 4. Xử lý lỗi
//     cdr?.detectChanges();
//     throw this.handleError(error); // Giả sử handleError trả về Error object
//   }
// }

// Cách sử dụng trong component
// @Component({
//   // ...
// })
// export class MenuComponent {
//   private cdr = inject(ChangeDetectorRef);
//   menuItems: any[] = [];
//   loading = false;
//   async loadMenu() {
//     try {
//       this.loading = true;
//       this.cdr.detectChanges(); // Cập nhật trạng thái loading
//       // Gọi service và chờ kết quả
//       this.menuItems = await this.menuService.getMenuByUser('current-user-id', this.cdr);
//     } catch (error) {
//       console.error('Lỗi tải menu:', error);
//     } finally {
//       this.loading = false;
//       this.cdr.detectChanges(); // Cập nhật UI cuối cùng
//     }
//   }
// }