import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { WeatherComponent } from './components/weather/weather.component';
import { MoviesComponent } from './components/movies/movies.component';
import { RouterModule, Routes } from '@angular/router';
import { ApplicationApiContext } from './Services/ApplicationApiContext';



@NgModule({
  declarations: [
    AppComponent,
    WeatherComponent,
    MoviesComponent
    ApplicationApiContext
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
