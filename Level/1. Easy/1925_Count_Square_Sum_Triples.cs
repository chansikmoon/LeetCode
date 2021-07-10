public class Solution {
    public int CountTriples(int n) {
        int ret = 0;
        
        for (int i = 1; i <= n; i++)
        {
            for (int a = 1; a < n - 1; a++)
            {
                for (int b = a + 1; b < n; b++)
                {
                    if ((a*a + b * b) == i * i)
                        ret++;
                }
            }
        }
        
        return ret * 2;
    }
}