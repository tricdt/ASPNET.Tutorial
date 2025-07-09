import { inject, Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { AuthService } from '../services';
import { SystemConstants } from '../constants';

@Injectable({ providedIn: 'root' })
export class AuthGuard implements CanActivate {

  constructor(private router: Router, private authService: AuthService) { }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
   if (this.authService.isAuthenticated()) {
      const functionCode = route.data['functionCode'] as string;
      const profile = this.authService.profile;
      const permissions = JSON.parse(String(profile['Permissions']));
      if (permissions && permissions.filter(x => x === functionCode + '_' + SystemConstants.VIEW_ACTION).length > 0) {
        return true;
      } else {
        this.router.navigate(['/access-denied'], {
          queryParams: { redirect: state.url }
        });
        return false;
      }
    }
    this.router.navigate(['/login'], { queryParams: { redirect: state.url }, replaceUrl: true });
    return false;
  }
}

// canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
//       const requiredPermissions = route.data.permissions; // Define required permissions in route
//       return this.userManager.getUser ().then(user => {
//         return user && user.profile.permissions.includes(requiredPermissions);
//       });
//     }