export interface Movie {
  _id: string;
  title: string;
  director: string;
  release_year: number;
  genre: string[];
  actors: string[];
  country: string;
  duration_minutes: number;
  is_released: boolean;
  rating: number;
  slug: string;
  image: string;
  description: string;
  watched: boolean;
}



