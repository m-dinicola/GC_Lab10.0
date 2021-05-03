using System;
using System.Collections.Generic;
using System.Text;

namespace Lab10._0_GC
{
    class FilmLibrary
    {
        //fields

        private List<Movie> genreMovies;            //a list of movies of the set genre, in alpha order
        private string genre;

        //properties
        public List<Movie> Movies { get; set; }     //the list of movies

        public List<Movie> GenreMovies          //a list of movies matching the set genre property, corresponds to the field
        {
            get
            {
                return genreMovies;
            }
        }
        public string Genre {                       //the set genre. Setting this prop updates the genreMovies list.
            get
            {
                return genre;
            }

            set 
            {
                genre = value.ToLower();
                genreMovies.Clear();                //clearing the old list
                foreach(Movie m in Movies)
                {
                    if (m.Category == genre)
                    {
                        genreMovies.Add(m);         //adding movies to the list if they match genre
                    }
                    genreMovies.Sort(TitleSort);    //alphabetizing the list
                }

            } 
        }

        //constructors
        public FilmLibrary(List<Movie> movies)
        {
            Movies = movies;
            genreMovies = new List<Movie>();
            Genre = "unset";
        }

        public FilmLibrary(List<string[]> csv)
        {
            Movies = new List<Movie>();
            foreach(string[] line in csv)
            {
                Movies.Add(new Movie(line));
            }
            genreMovies = new List<Movie>();
            Genre = "unset";
        }

        //methods
        //Allows the setting of the genre as a method.
        public FilmLibrary SetGenre(string genre)
        {
            Genre = genre.ToLower();
            return this;
        }

        //Writes a list of movies in the current set genre to the console.
        public void PrintGenre()
        {
            Console.WriteLine($"There are {genreMovies.Count} {Genre} movies in the list:");
            foreach (Movie m in genreMovies)
            {
                Console.WriteLine(m.Title);
            }
        }

        //overload allows setting and printing a list of movies of the genre in one step.
        public void PrintGenre(string _genre)
        {
            Genre = _genre;
            PrintGenre();
        }

        //allows sorting of film list by title
        private static int TitleSort(Movie x, Movie y)
        {
            return x.Title.CompareTo(y.Title);
        }
    }
}
