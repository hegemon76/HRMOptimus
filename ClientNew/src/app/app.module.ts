import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
<<<<<<< HEAD
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
=======
import { HttpClientModule } from '@angular/common/http'
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
>>>>>>> 3a613ca738840f39440cbf5b487a7c50bcc60a2b

import { AppComponent } from './app.component';
import { SidebarComponent } from './core/sidebar/sidebar.component';
import { MainComponent } from './core/main/main.component';
import { LoginComponent } from './core/login/login.component';

@NgModule({
<<<<<<< HEAD
  declarations: [AppComponent, SidebarComponent, MainComponent, LoginComponent],
  imports: [BrowserModule, AppRoutingModule, FormsModule, HttpClientModule],
=======
  declarations: [
    AppComponent,
    SidebarComponent,
    MainComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
>>>>>>> 3a613ca738840f39440cbf5b487a7c50bcc60a2b
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {}
