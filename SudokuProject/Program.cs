using System;

namespace SudokuProject
{
    class Program
    {
        static int size = 9;

        static int[,] entryGrid()
        {

            int row = size;
            int column = size;

            int[,] grid = new int[row, column];

            for (int rowIndicator = 0; rowIndicator < row; rowIndicator++)
            {
                for (int colIndicator = 0; colIndicator < column; colIndicator++)
                {
                    Console.WriteLine("Do you want to Enter number: (Type yes if you want or press any key to exit & solve)");
                    string option = Console.ReadLine();


                    if (option == "yes" || option == "Yes")
                    {
                        Console.WriteLine("Enter the row you want to insert the number in it: (from 0 to 8)");
                        try
                        {
                            rowIndicator = Convert.ToInt32(Console.ReadLine());

                        }

                        catch
                        {
                            Console.WriteLine("Invalid Input.. Please enter number between 0-8");
                        }

                        Console.WriteLine("Enter column: (from 0 to 8) ");
                        try
                        {
                            colIndicator = Convert.ToInt32(Console.ReadLine());

                        }

                        catch
                        {
                            Console.WriteLine("Invalid Input.. Please enter number between 0-8");
                        }


                        Console.WriteLine("Enter value: (from 1 to 9) ");
                        try
                        {
                            grid[rowIndicator, colIndicator] = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine($"row = {rowIndicator + 1} " + $" col = {colIndicator + 1}" + " value: " + grid[rowIndicator, colIndicator]);
                        }
                        catch
                        {
                            Console.WriteLine("Invalid Input..");
                        }
                    }
                    else
                    {
                        rowIndicator = 10;
                        colIndicator = 10;
                    }
                    Console.Write("\n");

                }

            }
            {

                Console.Write("\nSudoku before solved: \n");
                for (int printRow = 0; printRow < size; printRow++)
                {
                    Console.Write("\n");
                    for (int printCol = 0; printCol < size; printCol++)
                        Console.Write("|" + grid[printRow, printCol]);
                }
            }
            return grid;

        }
        static bool IsInRow(int[,] grid, int row, int col, int num)
        {

            for (int rowIndicator = 0; rowIndicator <= 8; rowIndicator++)
                if (grid[row, rowIndicator] == num)
                    return false;

            return true;
        }

        static bool IsInCol(int[,] grid, int row, int col, int num)
        {

            for (int colIndicator = 0; colIndicator <= 8; colIndicator++)
                if (grid[colIndicator, col] == num)
                    return false;

            return true;
        }

        static bool IsInBox(int[,] grid, int row, int col, int num)
        {
            int startRow = row - row % 3;
            int startCol = col - col % 3;

            for (int rowIndicator = 0; rowIndicator < 3; rowIndicator++)
            {
                for (int colIndicator = 0; colIndicator < 3; colIndicator++)
                {
                    if (grid[rowIndicator + startRow, colIndicator + startCol] == num)
                    {

                        return false;
                    }
                }
            }
            return true;
        }
        static bool isValid(int[,] grid, int row, int col, int num) //Make a decision about canidate Number depending on Sudoku rules
        {
            return (IsInRow(grid, row, col, num) &&
                IsInCol(grid, row, col, num) &&
                IsInBox(grid, row, col, num));
        }
        static bool solve(int[,] grid, int row, int col)
        {

            if (row == size - 1 && col == size) //Reached the end of table So will returned true to main for printing the table.

                return true;

            if (col == size) // Reached column 9 in current row, SO you must to move to the next row.
            {
                row++;
                col = 0;
            }

            if (grid[row, col] != 0) // if cell not empty, already have a number.. So move to next cell by callBack solve
                return solve(grid, row, col + 1);

            for (int num = 1; num < 10; num++)
            {

                if (isValid(grid, row, col, num)) //if the canidate Number is approperiate for this cell
                {

                    grid[row, col] = num;

                    if (solve(grid, row, col + 1)) //after assign a number to cell you can move to next cell & callBack solve
                        return true;
                }

                grid[row, col] = 0; // if the canidate number wasn't approperiate go to next number within the same cell


            }
            return false;

        }

        static void print(int[,] grid)
        {
            Console.WriteLine("\n");
            Console.Write("\nSudoku after Solved: \n");
            for (int printRow = 0; printRow < size; printRow++)
            {
                Console.Write("\n");
                for (int printCol = 0; printCol < size; printCol++)
                    Console.Write("|" + grid[printRow, printCol]);
            }

        }

        static void Main(string[] args)
        {
            Console.WriteLine($"\t\t\t\t Welcome in Sudoko Game \n\t\t\tMy Compter is exited to play with you\n\t\t\t\t\t Be Ready!! \n");
            int[,] grid = entryGrid();

            if (solve(grid, 0, 0))
            {
                print(grid);
            }
            else
            {
                Console.WriteLine("\n\t\t\t\tNo solution");
            }

        }

    }

}