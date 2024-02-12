import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Movie } from '../../Models/Movies';

@Injectable({
  providedIn: 'root'
})
export class MovieService {
  private apiUrl = 'https://localhost:7224';

  constructor(private http: HttpClient) { }

  // Метод для получения списка всех фильмов
  getMovies(): Observable<Movie[]> {
    return this.http.get<Movie[]>(`${this.apiUrl}/movie`);
  }

  // Метод для получения информации о конкретном фильме по его ID
  getMovieById(movieId: string): Observable<Movie> {
    return this.http.get<Movie>(`${this.apiUrl}/movie/${movieId}`);
  }

  // Другие методы, например, для добавления, обновления и удаления фильмов
}
