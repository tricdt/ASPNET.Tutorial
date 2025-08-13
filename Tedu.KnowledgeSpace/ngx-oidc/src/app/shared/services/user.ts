import { Injectable } from '@angular/core';
import { BaseService } from './base';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { UtilitiesService } from './utilities';
import { environment } from 'environtments/environment';
import { catchError, map } from 'rxjs';

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
