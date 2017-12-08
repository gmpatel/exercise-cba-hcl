using System.Collections.Generic;
using System.ServiceModel;
using MoviesLibrary;

namespace MoviesLibraryExercise.ServiceLibrary
{
    [ServiceContract]
    public interface IMovieLibrary
    {
        [OperationContract]
        List<MovieData> GetMovies();

        [OperationContract]
        MovieData GetMovieById(int id);

        [OperationContract]
        List<MovieData> GetMoviesInOrder(MovieField field);

        [OperationContract]
        List<MovieData> SearchMovies_Logic_1(string searchString);

        [OperationContract]
        List<MovieData> SearchMovies_Logic_2(string searchString);

        [OperationContract]
        int CreateMovie(MovieData movie);

        [OperationContract]
        void UpdateMovie(MovieData movie);
    }
}