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

        // Function to check if an array is
        // subarray of another array
        static bool isSubset(int[] arr1,
          int[] arr2,
          int m, int n)
        {
            int i = 0;
            int j = 0;
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < m; j++)
                    if (arr2[i] == arr1[j])
                        break;

                /* If the above inner loop
                was not broken at all then
                arr2[i] is not present in
                arr1[] */
                if (j == m)
                    return false;
            }

            /* If we reach here then all
            elements of arr2[] are present
            in arr1[] */
            return true;
        }

        public static bool checkEquality(int[] first, int[] second)
        {
            bool isEqual = isSubset(first, second, first.Length, second.Length);
            //bool isSubset = !second.Except(first).Any();
            return isEqual;
        }

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
                                if (compareLog.Length > 14 & checkEquality(compareLog, nums))
                                {
                                    Console.BackgroundColor = ConsoleColor.Blue;
                                    Console.WriteLine("BINGO! YOU WIN. All your numbers match");
                                    score = score + 1500;
                                    Console.WriteLine("Your score is " + score);
                                    Console.WriteLine("Thank you for playing :)");
                                    Console.ResetColor();
                                }
                                else if (compareLog.Length > 4)
                                {
                                    Console.BackgroundColor = ConsoleColor.Blue;
                                    if (!row1Win && checkEquality(compareLog, row1))
                                    {
                                        row1Win = true;
                                        Console.WriteLine("BINGO! Your row 1 matched.");
                                        score = score + 100;
                                        Console.WriteLine("Your score is " + score);
                                    }
                                    if (!row2Win && checkEquality(compareLog, row2))
                                    {
                                        row2Win = true;
                                        Console.WriteLine("BINGO! Your row 1 matched.");
                                        score = score + 100;
                                        Console.WriteLine("Your score is " + score);
                                    }
                                    if (!row3Win && checkEquality(compareLog, row3))
                                    {
                                        row3Win = true;
                                        Console.WriteLine("BINGO! Your row 1 matched.");
                                        score = score + 100;
                                        Console.WriteLine("Your score is " + score);
                                    }
                                    Console.ResetColor();

                                }
                                Console.WriteLine();
                                break;
                            }
                        }
                    }
                }
                //PRINT ARRAY//
               

    }
}