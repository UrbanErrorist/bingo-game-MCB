using System;
using System.Linq;

public static class Extensions
{
    public static T[] SubArray<T>(this T[] array, int offset, int length)
    {
        T[] result = new T[length];
        Array.Copy(array, offset, result, 0, length);
        return result;
    }
}

namespace challenge_test
{
    class Program
    {


        static void Main(string[] args)
        {

            int[] nums = Enumerable.Range(1, 16).ToArray();
            Random rnd = new Random();

            for (int i = 0; i < nums.Length; i++)
            {
                int randomIndex = rnd.Next(1, nums.Length);
                int temp = nums[randomIndex];
                nums[randomIndex] = nums[i];
                nums[i] = temp;
            }

            int[] row1 = nums.SubArray(0, 5);
            int[] row2 = nums.SubArray(5, 5);
            int[] row3 = nums.SubArray(10, 5);

            int tester = 0;
            int index = 0; //int index represents the amount of numbers that have been drawn and the position to dump new numbers into ARRAY
            string menu = null;
            bool DupChk = false;
            int upper = 60; //int upper will be the amount of numbers that can be drawn
            int score = 0;
            bool row1Win = false;
            bool row2Win = false;
            bool row3Win = false;

            int[] log = new int[upper]; //creates Array with a size determined by user input
            int[] logOrdered = new int[upper]; //creates second Array that will later be used to sort values by lowest-to-highest

            //RANDOM INITIATOR 
            Random r = new Random(); //Random number generator
            int rInt = r.Next(1, upper);
            Console.WriteLine("Welcome to the MCB Bingo Club.");

            while (menu != "4")
            {

                //MAIN MENU//
                Console.WriteLine("Score = " + score + ". Upper Limit = " + upper + ". Numbers Drawn = " + index);

                for (int i = 0; i < row1.Length; ++i)
                {
                    if (Array.IndexOf(log, row1[i]) != -1)
                    {

                        if (row1[i] == rInt)
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.Write(row1[i] + " ");
                            Console.ResetColor();

                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.Write(row1[i] + " ");
                            Console.ResetColor();
                        }
                    }
                    else
                    {
                        Console.Write(row1[i] + " ");
                    }

                }
                Console.WriteLine("\n-----------------------");

                for (int i = 0; i < row2.Length; ++i)
                {
                    if (Array.IndexOf(log, row2[i]) != -1)
                    {

                        if (row2[i] == rInt)
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.Write(row2[i] + " ");
                            Console.ResetColor();

                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.Write(row2[i] + " ");
                            Console.ResetColor();
                        }
                    }
                    else
                    {
                        Console.Write(row2[i] + " ");
                    }

                }
                Console.WriteLine("\n-----------------------");

                for (int i = 0; i < row3.Length; ++i)
                {
                    if (Array.IndexOf(log, row3[i]) != -1)
                    {

                        if (row3[i] == rInt)
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.Write(row3[i] + " ");
                            Console.ResetColor();

                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.Write(row3[i] + " ");
                            Console.ResetColor();
                        }
                    }
                    else
                    {
                        Console.Write(row3[i] + " ");
                    }

                }
                Console.WriteLine("\n-----------------------");

                Console.WriteLine("1. Draw next number");
                Console.WriteLine("2. View all drawn numbers");
                Console.WriteLine("3. Check specific numbers");
                Console.WriteLine("4. Exit");

                menu = Console.ReadLine();

                //NUMER DRAW//
                if (menu == "1")
                {

                    if (index >= upper & index >= 30)
                    { //If there are no more numbers to be drawn function stops
                        Console.Clear();
                        Console.WriteLine("You have reached the upper limit. You Lose this round");
                    }
                    else
                    {

                        while (tester == 0)
                        { //drawns a random number and searches the array to see if drawn number already exists. If it does will draw another number and repeat until an original number is drawn
                            DupChk = false;
                            rInt = r.Next(1, upper + 1);
                            for (int i = 0; i < index; i++)
                            {
                                if (log[i] == rInt) DupChk = true;
                            }
                            if (DupChk == false)
                            {
                                log[index] = rInt;
                                int[] compareLog = log.SubArray(0, index);
                                index++;

                                Console.WriteLine("You have drawn " + rInt + "!");
                                //Console.WriteLine("=======> " + checkEquality(compareLog, row1));
                                //Console.WriteLine("=======> " + checkEquality(compareLog, row2));
                               
                                }
                                Console.WriteLine();
                                break;
                            }
                        }
                    }
                }
                //PRINT ARRAY//
                else if (menu == "2")
                {

                    Console.Clear();

                    Console.WriteLine("1. Print numbers in drawn order");
                    Console.WriteLine("2. Print numbers in sequential order");
                    string Twochoice = Console.ReadLine();

                    //Print in drawn order//
                    if (Twochoice == "1")
                    {
                        Console.Clear();
                        for (int i = 0; i < index; i++)
                        {
                            Console.WriteLine((i + 1) + ". " + log[i]);
                        }
                    }
                    //print in sequence//               
                    else if (Twochoice == "2")
                    {
                        log.CopyTo(logOrdered, 0); //Copy's the original array to a new one
                        Array.Sort(logOrdered); //Sort by lowest to highest   
                        Console.Clear();
                        int difference = upper - index; //Obtains the difference between the current index position and the upper limit.  

                        //The index will start printing from this value to avoid any ZERO values that get sorted to the bottom of the array
                        //EXAMPLE: Array with 3 values (index) and UPPER limit of 5 containts: [2,3,4,0,0,]. SORTING RETURNS: [0,0,2,3,4] WHEN WRITING THIS WILL RETURN "0,0,2" because the print loop only assumes 3 values exist
                        //EXAMPLE CONT: By getting the difference between the upper and index (5 - 3 = 2) and starting to write from this position in the array we will skip all zero's are return only drawn values

                        for (int i = (upper - index); i < upper; i++)
                        {
                            Console.WriteLine((i + 1 - difference) + ". " + logOrdered[i]);
                        }

                    }
                    else Console.WriteLine("Invalid selection");
                }
                //FIND NUMBER//
                else if (menu == "3")
                {
                    bool numChk = false;
                    int search = 0;
                    Console.Clear();
                    Console.WriteLine("Enter the number you would like to confirm");

                    while (tester == 0)
                    {
                        bool nub = int.TryParse(Console.ReadLine(), out search);
                        if (search < 0 || nub == false)
                            Console.WriteLine("Enter valid number");
                        else if (search == 0)
                            Console.WriteLine("You need to enter a value larger than 0!");
                        else break;
                    }

                    for (int i = 0; i < index; i++)
                    { //Searches the array to see if user inputted number appears in array
                        if (log[i] == search) numChk = true;
                    }
                    if (numChk == true) Console.WriteLine("The number " + search + " has been drawn");
                    else Console.WriteLine("The number " + search + " has NOT been drawn");

                }
                //EXIT GAME//
                else if (menu == "4")
                {
                    Console.WriteLine("Thank you for playing :)");
                }
                else Console.WriteLine("Invalid Selection");

            }
        }

    }
}