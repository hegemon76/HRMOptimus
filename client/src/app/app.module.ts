import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AccountModule } from './account/account.module';
import { AppComponent } from './app.component';
<<<<<<< HEAD
import { HeaderComponent } from './layout/header/header.component';
import { SidebarComponent } from './layout/sidebar/sidebar.component';
import { MainComponent } from './layout/main/main.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
=======
import { SidebarComponent } from './core/sidebar/sidebar.component';
import { MainComponent } from './core/main/main.component';
import { LoginComponent } from './core/login/login.component';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';
>>>>>>> e71cf1a96e22c3097d2355caa133dd8cb9ac0b5a
import { LayoutModule } from '@angular/cdk/layout';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatIconModule } from '@angular/material/icon';
import { MatListModule } from '@angular/material/list';
<<<<<<< HEAD
import { MatSlideToggleModule } from '@angular/material/slide-toggle';

@NgModule({
  declarations: [
    AppComponent,
    SidebarComponent,
    MainComponent,
    HeaderComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    MatSlideToggleModule,
    AccountModule,
    BrowserAnimationsModule,
    LayoutModule,
    MatToolbarModule,
    MatButtonModule,
    MatSidenavModule,
    MatIconModule,
    MatListModule
  ],
=======

@NgModule({
  declarations: [AppComponent, SidebarComponent, MainComponent, LoginComponent],
  imports: [BrowserModule, AppRoutingModule, FormsModule, NoopAnimationsModule, LayoutModule, MatToolbarModule, MatButtonModule, MatSidenavModule, MatIconModule, MatListModule],
>>>>>>> e71cf1a96e22c3097d2355caa133dd8cb9ac0b5a
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {}
