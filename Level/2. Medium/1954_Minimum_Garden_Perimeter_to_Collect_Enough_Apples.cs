public class Solution {
    public long MinimumPerimeter(long neededApples) {
        long peri = 0;
        
        for (long i = 1; neededApples > 0; i++)
        {
            long corner = i * 2, other = 3 * i * (i - 1);
            long apples = 4 * (corner + other + i);
            neededApples -= apples;
            peri = i;
        }
        
        return peri * 8;
    }
}

/*

corner = i * 2
other = 
(corner - 1) * corner / 2 - (i) * (i + 1) / 2 => provides the sum of i + 1 to corner

corner = 6
(corner - 1) * corner / 2 = 5 * 6 / 2 = 15, sum of 1 to 5
i * (i + 1) / 2 = (3 + 4) / 2 = 6, sum of 1 to 3
15 - 6 = 9, which is sum of 4 and 5.
9 * 2 gives sum of the hori and vert.

y
3 4 5 6
2 3 4 5
1 2 3 4
0 1 2 3 x

((i * 2 - 1) * (i * 2) / 2 - i * (i + 1) / 2) * 2
(((i * 2 - 1) * (i * 2) - i * (i + 1)) / 2) * 2
(2i - 1) * 2i - i * (i + 1)
4i^2 - 2i - i^2 - i
3i^2 - 3i
3 * i (i - 1)

*/