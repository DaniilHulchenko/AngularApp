import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, map } from 'rxjs';
import { Movie } from '../../Models/Movies';
import { ApplicationApiContext } from '../ApplicationApiContext';

@Injectable({
  providedIn: 'root'
})
export class MovieService {

  constructor(private http: HttpClient) { }

  // Метод для получения списка всех фильмов
  getMovies(): Observable<Movie[]> {
    return this.http.get<Movie[]>(`movie`);
  }

  // Метод для получения информации о конкретном фильме по его ID
  getMovieById(movieId: string): Observable<Movie> {
    return this.http.get<Movie>(`movie/${movieId}`);
  }



  //constructor(private http: HttpClient, private Config: ApplicationApiContext) { }
  //private apiUrl?: string;
  //ngOnInit() {
  //  this.Config.getConfig().subscribe(config => {
  //    this.apiUrl = config.apsapiurl;
  //    console.log(this.apiUrl); // Make sure apiUrl is set correctly
  //  });
  //}
  //// Метод для получения списка всех фильмов
  //getMovies(): Observable<Movie[]> {
  //  return this.http.get<Movie[]>(`${this.apiUrl}/movie`);
  //}

  //// Метод для получения информации о конкретном фильме по его ID
  //getMovieById(movieId: string): Observable<Movie> {
  //  return this.http.get<Movie>(`${this.apiUrl}/movie/${movieId}`);
  //}
}
