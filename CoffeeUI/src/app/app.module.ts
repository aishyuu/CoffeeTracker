import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { DashboardComponent } from './dashboard/dashboard.component';
import { DisplayAllComponent } from './display-all/display-all.component';

import { HttpClientModule } from '@angular/common/http';
import { EditComponent } from './edit/edit.component'

@NgModule({
  declarations: [
    AppComponent,
    DashboardComponent,
    DisplayAllComponent,
    EditComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
