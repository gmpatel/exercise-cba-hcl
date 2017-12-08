using System;
using System.Collections.Generic;
using System.Linq;
using MoviesLibrary;

namespace MoviesLibraryExercise.ServiceLibrary
{
    public class MovieLibrary : IMovieLibrary
    {
        public List<MovieData> GetMovies()
        {
            return Global.GetMovies();
        }

        public MovieData GetMovieById(int id)
        {
            return Global.GetMovies().First(x => x.MovieId == id);
        }

        public List<MovieData> GetMoviesInOrder(MovieField field)
        {
            switch (field)
            {
                case MovieField.Classification:
                    return Global.GetMovies().OrderBy(x => x.Classification).ToList();
                case MovieField.Genre:
                    return Global.GetMovies().OrderBy(x => x.Genre).ToList();
                case MovieField.MovieId:
                    return Global.GetMovies().OrderBy(x => x.MovieId).ToList();
                case MovieField.Rating:
                    return Global.GetMovies().OrderBy(x => x.Rating).ToList();
                case MovieField.ReleaseDate:
                    return Global.GetMovies().OrderBy(x => x.ReleaseDate).ToList();
                case MovieField.Title:
                    return Global.GetMovies().OrderBy(x => x.Title).ToList();
                default:
                    return null;
            }
        }

        public List<MovieData> SearchMovies_Logic_1(string searchString)
        {
            // Checking search string.
            searchString = string.IsNullOrEmpty(searchString) ? string.Empty : searchString.ToLower();

            // Query. Using reflection based linq extension method. Extension Method = CheckObjectPropertiesContains
            return
                GetMovies().AsQueryable()
                    .Where(m => m.CheckObjectPropertiesContains(searchString))
                    .ToList();
        }

        public List<MovieData> SearchMovies_Logic_2(string searchString)
        {
            // Checking search string.
            searchString = string.IsNullOrEmpty(searchString) ? string.Empty : searchString.ToLower();

            // Generate your predicate.
            Func<object, bool> checkContains = s => s != null && s.ToString().ToLower().Contains(searchString);

            // Query. Using simple linq in-line query using predecate to avoid code duplication.
            return 
                (from movie in GetMovies()
                 where
                    checkContains((movie.Cast == null) ? null : string.Join(" ", movie.Cast)) ||
                    checkContains(movie.Title) ||
                    checkContains(movie.Classification) ||
                    checkContains(movie.Genre) ||
                    checkContains(movie.MovieId) ||
                    checkContains(movie.Rating) ||
                    checkContains(movie.ReleaseDate)
                 select movie).ToList();
        }

        public int CreateMovie(MovieData movie)
        {
            return Global.GetRepository().Create(movie);
        } 

        public void UpdateMovie(MovieData movie)
        {
            Global.GetRepository().Update(movie);
        }
    }
}