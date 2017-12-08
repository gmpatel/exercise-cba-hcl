using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MoviesLibrary;

namespace MoviesLibraryExercise.ServiceLibrary
{
    internal static class Global
    {
        // Static repository & local copy of data will be refreshed every day at 2pm
        // Caching is another option for not querying data again and again

        private static MovieDataSource movieRepository;
        private static List<MovieData> movies;

        internal static MovieDataSource GetRepository()
        {
            return movieRepository ?? (movieRepository = new MovieDataSource());
        }

        internal static List<MovieData> GetMovies()
        {
            if (movies == null || movies.Count == 0) // Creates local copy of movies if local copy if null OR count of local movies is 0
            {
                movies = GetRepository().GetAllData();    
            }
            else if (DateTime.Now.ToString("HH:mm").Equals("02:00")) // Refresh local copy of movies every 24 hours ( at 02:00 AM in the morning )
            {
                movies = GetRepository().GetAllData();    
            }

            return movies;
        }
    }
}