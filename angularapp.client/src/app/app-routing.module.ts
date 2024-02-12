import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MoviesComponent } from './components/movies/movies.component';
import { WeatherComponent } from './components/weather/weather.component';

const routes: Routes = [
  { path: "", component: WeatherComponent },
  { path: "cinema", component: MoviesComponent }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
