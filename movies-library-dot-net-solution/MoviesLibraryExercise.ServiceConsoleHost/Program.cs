using System;
using System.ServiceModel;
using MoviesLibraryExercise.ServiceLibrary;

namespace MoviesLibraryExercise.ConsoleServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = new ServiceHost(typeof(MovieLibrary));

            try
            {
                host.Open();
                PrintServiceInfo(host);
                host.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.ReadKey();
                host.Abort();
            }
        }

        static void PrintServiceInfo(ServiceHostBase host)
        {
            Console.WriteLine();
            Console.WriteLine("  {0} is up and running...", host.Description.ServiceType);

            foreach (var se in host.Description.Endpoints)
            {
                Console.WriteLine();
                Console.WriteLine("      End Point > {0}", se.Address.ToString().Replace("localhost", Environment.MachineName.ToLower()));
                Console.WriteLine("      Binding   > {0}", se.Binding.Name);
                Console.WriteLine("      Contract  > {0}", se.Contract.Name);
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("  Press any key to stop...");
            Console.CursorVisible = false;

            Console.ReadKey();
        }
    }
}