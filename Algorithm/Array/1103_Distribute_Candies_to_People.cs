public class Solution {
    // Time Complexity: O(sqrt(candies))
    // The total number of distributed candies is c, x * (x + 1) / 2 = c or O(x^2) = O (c) ==> O(x) = O(sqrt(c))
    // Space Complexity: O(n) or O(1) depends on if you count the return array or not. 
    public int[] DistributeCandies(int candies, int num_people) {
        int[] arr = new int[num_people];

        for (int i = 0; candies > 0; i++)
        {
            arr[i % n] += Math.Min(candies, i + 1);
            candies -=  i + 1;
        }
        
        return arr;
    }

    private int[] BruteForceSolution(int candies, int num_people)
    {
        int[] arr = new int[num_people];
        int n = 0;
        while (candies > 0)
        {
            for (int i = 0; i < num_people && candies > 0; i++)
            {
                int giveOut = candies >= n + i + 1 ? n + i + 1 : candies;
                arr[i] += giveOut;
                candies -= giveOut;
            }
            n += num_people;
        }
        
        return arr;
    }
}