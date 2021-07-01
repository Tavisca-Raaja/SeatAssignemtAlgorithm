using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeatAssignmentAlgorithm
{
    public static class SeatProcessor
    {
        private static List<string[,]> seats;
        private static int _paxCount;
        private static int _maxRow;
        private static int _currentFilledSeatsCount =1;

        public static void CreateSeats(List<int[]> seatLayoutDimension)
        {
            seats = new List<string[,]>();

            // seat Layout creation
            for(int seat = 0; seat < seatLayoutDimension.Count; seat++)
            {
                var seatBox = new string[seatLayoutDimension[seat][1], seatLayoutDimension[seat][0]];

                seats.Add(seatBox);
            }

            // finding max row length
            _maxRow = FindMaxRow();

            //updating seat type "Aisle,Middle,Window"
            UpdateSeatType();

            for (int i = 0; i < seats.Count; i++)
            {
                for (int k = 0; k < seats[i].GetLength(1); k++)
                {
                    Console.Write(seats[i][0, k] + "  ");
                }
                Console.Write("  ");
            }

            Console.WriteLine();

        }

        public static void AssignSeats(int paxCount)
        {
            _paxCount = paxCount;
            FillRequestedSeatType("A");
            FillRequestedSeatType("W");
            FillRequestedSeatType("M");

            SeatMap();
        }

        private static void UpdateSeatType()
        {
            for (int currentSeatLayout = 0; currentSeatLayout < seats.Count; currentSeatLayout++)
            {
                for (int currentRow = 0; currentRow < seats[currentSeatLayout].GetLength(0); currentRow++)
                {
                    for (int currentColumn = 0; currentColumn < seats[currentSeatLayout].GetLength(1); currentColumn++)
                    {
                        if(currentSeatLayout == 0)
                        {
                            if (currentColumn == 0)
                            {
                               seats[currentSeatLayout][currentRow, currentColumn] = "W";
                            }
                            else if(currentColumn == seats[currentSeatLayout].GetLength(1)-1)
                            {
                                seats[currentSeatLayout][currentRow, currentColumn] = "A";
                            }
                            else
                            {
                                seats[currentSeatLayout][currentRow, currentColumn] = "M";
                            }
                        }

                        if(currentSeatLayout == seats.Count-1)
                        {
                            if (currentColumn == 0)
                            {
                                seats[currentSeatLayout][currentRow, currentColumn] = "A";
                            }
                            else if (currentColumn == seats[currentSeatLayout].GetLength(1) - 1)
                            {
                                seats[currentSeatLayout][currentRow, currentColumn] = "W";
                            }
                            else
                            {
                                seats[currentSeatLayout][currentRow, currentColumn] = "M";
                            }
                        }

                        if (currentSeatLayout != 0 && currentSeatLayout != seats.Count - 1)
                        {
                            if(currentColumn ==0 || currentColumn == seats[currentSeatLayout].GetLength(1) - 1)
                            {
                                seats[currentSeatLayout][currentRow, currentColumn] = "A";
                            }
                            else
                            {
                                seats[currentSeatLayout][currentRow, currentColumn] = "M";
                            }
                        }
                    }
                }
            }
        }

        private static void FillRequestedSeatType(string seatType)
        {
            int currentRow = 0;
            while(currentRow < _maxRow)
            {
                for (int currentLayout = 0; currentLayout < seats.Count; currentLayout++)
                {
                    for (int currentColumn = 0; currentColumn < seats[currentLayout].GetLength(1); currentColumn++)
                    {
                        if (currentRow < seats[currentLayout].GetLength(0) &&  seats[currentLayout][currentRow, currentColumn] == seatType && 
                            _currentFilledSeatsCount <= _paxCount)
                        {
                            seats[currentLayout][currentRow, currentColumn] = _currentFilledSeatsCount.ToString();
                            _currentFilledSeatsCount++;
                        }
                    }
                }
                currentRow++;
            }
            
        }

        private static void SeatMap()
        {
            int currentRow = 0;
            while (currentRow < _maxRow)
            {
                for (int i = 0; i < seats.Count; i++)
                {
                    if (currentRow < seats[i].GetLength(0))
                    {
                        for (int k = 0; k < seats[i].GetLength(1); k++)
                        {

                            Console.Write(seats[i][currentRow, k]);

                            if (seats[i][currentRow, k].Length == 1)
                            {
                                Console.Write("  ");
                            }
                            else
                            {
                                Console.Write(" ");
                            }

                        }
                    }
                    else
                    {
                        for(int s =0;s< seats[i].GetLength(1);s++)
                            Console.Write("   ");
                    }
                    Console.Write("  ");
                }
                currentRow++;
                Console.WriteLine();
            }
        }

        private static int FindMaxRow()
        {
            int max = 0;

            for(int i=0;i< seats.Count; i++)
            {
                if(seats[i].GetLength(1) > max)
                {
                    max = seats[i].GetLength(1);
                }
            }

            return max;
        }
    }
}
