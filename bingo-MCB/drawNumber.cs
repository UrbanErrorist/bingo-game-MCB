using System;
namespace bingo_MCB
{


    class DrawNumber
    {

        private int upperLimit;
        private int lowerLimit;

        public DrawNumber(int lower, int upper)
        {
            upperLimit = upper;
            lowerLimit = lower;
        }

        public int drawNumberFromCard()
        {
            Random r = new Random(); //Random number generator
            return r.Next(lowerLimit, upperLimit);
        }

    }
}

