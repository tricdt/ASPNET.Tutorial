import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { RouterModule } from '@angular/router';
import { AppRoutingModule } from './app-routing.module';
import { CommonModule } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';
import {
  BrowserAnimationsModule,
  provideAnimations,
  provideNoopAnimations
} from '@angular/platform-browser/animations';
import { AuthGuard } from './shared/guard/auth.guard';
import { AuthInterceptor } from './shared/interceptors/auth.interceptors';
import {
  HTTP_INTERCEPTORS,
  provideHttpClient,
  withInterceptorsFromDi
} from '@angular/common/http';

@NgModule({
  imports: [CommonModule, BrowserModule, BrowserAnimationsModule, AppRoutingModule],
  exports: [],
  declarations: [AppComponent],
  providers: [
    AuthGuard,
    provideHttpClient(
      withInterceptorsFromDi() 
    ),
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule {}
