using System;
namespace bingo_MCB
{
    public class BingoCard
    {
        public int[] genrateCard(int row, int column, int upperLimit)
        {
            int total = row * column;
            int[] nums = Enumerable.Range(1, upperLimit).ToArray();
            Random rnd = new Random();

            for (int i = 0; i < nums.Length; i++)
            {
                int randomIndex = rnd.Next(1, nums.Length);
                int temp = nums[randomIndex];
                nums[randomIndex] = nums[i];
                nums[i] = temp;
            }
            

            return nums.SubArray(0, total, false);
        }

        public int[] generateCardRows(int[] generatedCardNumbers, int rowNumber, int Columns)
        {
            return generatedCardNumbers.SubArray(rowNumber, Columns, true);
        }
    }
}

