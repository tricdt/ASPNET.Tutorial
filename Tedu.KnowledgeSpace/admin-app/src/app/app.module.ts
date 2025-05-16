import { NgModule } from "@angular/core";
import { AppComponent } from "./app.component";
import { RouterModule } from "@angular/router";
import { AppRoutingModule } from "./app-routing.module";
import { CommonModule } from "@angular/common";
import { BrowserModule } from "@angular/platform-browser";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { AuthGuard } from "./shared/guard/auth.guard";
import { AuthInterceptor } from "./shared/interceptors/auth.interceptors";

@NgModule({
    imports: [
        CommonModule,
        BrowserModule,
        BrowserAnimationsModule,
        RouterModule,
        AppRoutingModule
    ],
    exports: [],
    declarations: [AppComponent],
    providers: [AuthGuard, {
        provide: 'HTTP_INTERCEPTORS',
        useClass: AuthInterceptor,
        multi: true
    }],
    bootstrap: [AppComponent]
})
export class AppModule { }