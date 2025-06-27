import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { UtilitiesService } from './utilities.service';
import { environment } from '@environments/environment';
import { catchError, map } from 'rxjs';
import { Function } from '@app/shared/models/function.model'; 
@Injectable({
  providedIn: 'root'
})
export class UsersService extends BaseService {
  private _sharedHeaders = new HttpHeaders();
  constructor(private http: HttpClient, private utilitiesService: UtilitiesService) {
    super();
  }

  getMenuByUser(userId: string) {
        return this.http.get<Function[]>(`${environment.apiUrl}/api/users/${userId}/menu`, { headers: this._sharedHeaders })
            .pipe(map(response => {
                const functions = this.utilitiesService.UnflatteringForLeftMenu(response);
                return functions;
            }), catchError(this.handleError));
    }
}
