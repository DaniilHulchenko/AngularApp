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

  constructor(private movieService: MovieService) { }

  public Movies: Movie[] = [];
  private i: number = 0;

  ngOnInit(): void {
    this.i = 1;
    this.movieService.getMovies(this.i).subscribe(
        (result) => {
          this.Movies = result;
        },
        (error) => {
          console.error(error);
        }
      );
  }
  getmoreMovies(to: number): void {
    //console.log(this.i)
    to += this.i;
    this.movieService.get_more_Movies(this.i, to).subscribe(
      (res) => {
        this.Movies = this.Movies.concat(res);
      });

  }
}
