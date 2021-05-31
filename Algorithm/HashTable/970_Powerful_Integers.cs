public class Solution
{
    // Let's say n is Log of x and m is Log of y.
    // TC: O(n * m)
    // SC: O(n * m)
    public IList<int> PowerfulIntegers(int x, int y, int bound)
    {
        var ret = new HashSet<int>();

        for (int i = 1; i < bound; i *= x)
        {
            for (int j = 1; i + j <= bound; j *= y)
            {
                ret.Add(i + j);

                if (y == 1)
                    break;
            }

            if (x == 1)
                break;
        }

        return ret.ToList();
    }

    public IList<int> BruteForce(int x, int y, int bound)
    {
        var xMap = new HashSet<int>();
        var yMap = new HashSet<int>();

        for (int prev = 0, val = 1; val < bound && prev != val;)
        {
            prev = val;
            xMap.Add(val);
            val *= x;
        }

        for (int prev = 0, val = 1; val < bound && prev != val;)
        {
            prev = val;
            yMap.Add(val);
            val *= y;
        }

        var ret = new HashSet<int>();

        foreach (var xVal in xMap)
        {
            foreach (var yVal in yMap)
            {
                if (xVal + yVal <= bound)
                    ret.Add(xVal + yVal);
            }
        }

        return ret.ToList();
    }
}