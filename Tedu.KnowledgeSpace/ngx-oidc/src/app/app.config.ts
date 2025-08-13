import {
  ApplicationConfig,
  provideBrowserGlobalErrorListeners,
  provideZoneChangeDetection,
} from '@angular/core';
import {
  provideRouter,
  withEnabledBlockingInitialNavigation,
  withInMemoryScrolling,
} from '@angular/router';
import Aura from '@primeng/themes/aura';
import { routes } from './app.routes';
import { OIDC_CONFIG_TOKEN } from './shared/oidc/oidc-config.token';
import { UserManagerSettings } from 'oidc-client-ts';
import { environment } from 'environtments/environment';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { providePrimeNG } from 'primeng/config';

const oidcConfig: UserManagerSettings = {
  authority: environment.authorityUrl,
  client_id: environment.clientId,
  redirect_uri: environment.adminUrl + '/auth-callback',
  post_logout_redirect_uri: environment.adminUrl,
  response_type: 'code',
  scope: 'api.knowledgespace openid profile',
  filterProtocolClaims: true,
  loadUserInfo: true,
  automaticSilentRenew: true,
  silent_redirect_uri: environment.adminUrl + '/silent-refresh.html',
};

export const appConfig: ApplicationConfig = {
  providers: [
    provideBrowserGlobalErrorListeners(),
    provideZoneChangeDetection({ eventCoalescing: true }),
    provideRouter(
      routes,
      withInMemoryScrolling({
        anchorScrolling: 'enabled',
        scrollPositionRestoration: 'enabled',
      }),
      withEnabledBlockingInitialNavigation()
    ),
    provideAnimationsAsync(),
    providePrimeNG({
      theme: { preset: Aura, options: { darkModeSelector: '.app-dark' } },
    }),

    {
      provide: OIDC_CONFIG_TOKEN,
      useValue: oidcConfig,
    },
  ],
};
