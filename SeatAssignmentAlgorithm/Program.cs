using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeatAssignmentAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            SeatProcessor.CreateSeats(new List<int[]> { new int[] { 3,2},
                                                        new int[] { 4,3},
                                                        new int[] { 2,3},
                                                        new int[] { 3,4}
                                                      });

            SeatProcessor.AssignSeats(30);
            Console.ReadKey();

            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }
    }
}
