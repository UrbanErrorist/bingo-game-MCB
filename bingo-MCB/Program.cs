using System;
using System.Linq;

public static class Extensions
{
    public static T[] SubArray<T>(this T[] array, int offset, int length, bool sort)
    {
        T[] result = new T[length];
        Array.Copy(array, offset, result, 0, length);
        if (sort) {
            Array.Sort(result);
        }
        
        return result;
    }
}

namespace bingo_MCB
{

    class Program
    {       

        static void Main(string[] args)
        {
            var bingoGame = new BingoGame(30);
            string resultMessage = bingoGame.playBingo();

            Console.WriteLine(resultMessage);
        }

    }
}