import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Movie } from '../../Models/Movies';
import { MovieService } from '../../Services/Movie/MovieService';

@Component({
  selector: 'app-movies',
  templateUrl: './movies.component.html',
  styleUrls: ['./movies.component.css']
})

//export class MoviesComponent implements OnInit {
//  public Movies: Movie[] = [];

//  constructor(private http: HttpClient) { }

//  ngOnInit() {
//    this.getMovies();
//  }

//  getMovies() {
//    this.http.get<Movie[]>('movie').subscribe(
//      (result) => {
//        this.Movies = result;
//      },
//      (error) => {
//        console.error(error);
//      }
//    );
//  }
//}
export class MoviesComponent implements OnInit {
  public Movies: Movie[] = [];

  constructor( private movieService: MovieService) { }

  ngOnInit(): void {
    this.movieService.getMovies().subscribe(
        (result) => {
          this.Movies = result;
        },
        (error) => {
          console.error(error);
        }
      );
  }
}
