using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using MoviesLibraryExercise.ConsoleApp.MoviesServiceReference;

namespace MoviesLibraryExercise.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceObject = new MovieLibraryClient();
            
            Console.WriteLine();
            Console.WriteLine("Press Any Key To Retrive All Movies...");
            Console.WriteLine();
            Console.ReadKey();

            var movies1 = serviceObject.GetMovies();

            Console.WriteLine("Total Movies = {0}", movies1.Count);

            Console.WriteLine();
            Console.WriteLine("Press Any Key To Retrive All Movies Again (Service Will Not Query Again To Third Pary Datasource Now & Results Will Be Quicker)");
            Console.WriteLine();
            Console.ReadKey();

            var movies2 = serviceObject.GetMovies();
            Console.WriteLine("Total Movies = {0}", movies2.Count);

            Console.WriteLine();
            Console.WriteLine("Press Any Key To Search Movies Contains 2013");
            Console.WriteLine();
            Console.ReadKey();

            var movies3 = serviceObject.SearchMovies_Logic_1("2013");
            Console.WriteLine("Total Movies Contains 2013 = {0}", movies3.Count);


            Console.WriteLine();
            Console.WriteLine("Press Any Key To List Movies In Order Of Title");
            Console.WriteLine();
            Console.ReadKey();

            var movies4 = serviceObject.GetMoviesInOrder(MovieField.Title);
            foreach (var movieData in movies4)
            {
                Console.WriteLine("Movies Title = {0}", movieData._title);    
            }
            
            Console.ReadKey();
        }
    }
}