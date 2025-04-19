import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Router } from '@angular/router';
import { Observable, throwError } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { SystemConstants } from '../common/system.constants';
import { AuthenService } from './authen.service';
import { NotificationService } from './notification.service';
import { UtilityService } from './utility.service';

@Injectable({
  providedIn: 'root', // Automatically provided in the root injector
})
export class DataService {
  private _headers: HttpHeaders;

  constructor(
    private _http: HttpClient,
    private _router: Router,
    private _authenService: AuthenService,
    private _notificationService: NotificationService,
    private _utilityService: UtilityService
  ) {
    this._headers = new HttpHeaders();
  }

  private _setAuthorizationHeader(): HttpHeaders {
    const token = this._authenService.getLoggedInUser()?.access_token;
    if (token) {
      return this._headers.set('Authorization', `Bearer ${token}`);
    }
    return this._headers;
  }

  get<T>(uri: string): Observable<T> {
    const headers = this._setAuthorizationHeader();
    return this._http.get<T>(`${SystemConstants.BASE_API}${uri}`, { headers }).pipe(
      map((data) => data),
      catchError(this._handleError.bind(this))
    );
  }

  post<T>(uri: string, data: any): Observable<T> {
    const headers = this._setAuthorizationHeader();
    return this._http.post<T>(`${SystemConstants.BASE_API}${uri}`, data, { headers }).pipe(
      map((data) => data),
      catchError(this._handleError.bind(this))
    );
  }

  put<T>(uri: string, data: any): Observable<T> {
    const headers = this._setAuthorizationHeader();
    return this._http.put<T>(`${SystemConstants.BASE_API}${uri}`, data, { headers }).pipe(
      map((data) => data),
      catchError(this._handleError.bind(this))
    );
  }

  delete<T>(uri: string): Observable<T> {
    const headers = this._setAuthorizationHeader();
    return this._http.delete<T>(`${SystemConstants.BASE_API}${uri}`, { headers }).pipe(
      map((data) => data),
      catchError(this._handleError.bind(this))
    );
  }

  postFile<T>(uri: string, data: FormData): Observable<T> {
    const headers = this._setAuthorizationHeader();
    return this._http.post<T>(`${SystemConstants.BASE_API}${uri}`, data, { headers }).pipe(
      map((data) => data),
      catchError(this._handleError.bind(this))
    );
  }

  private _handleError(error: HttpErrorResponse): Observable<never> {
    if (error.status === 401) {
      localStorage.removeItem(SystemConstants.CURRENT_USER);
      this._notificationService.printErrorMessage('You need to log in again.');
      this._utilityService.navigateToLogin();
    } else {
      const errMsg = error.error?.message || `${error.status} - ${error.statusText}`;
      this._notificationService.printErrorMessage(errMsg);
    }
    return throwError(() => new Error(error.message || 'Server error'));
  }
}
