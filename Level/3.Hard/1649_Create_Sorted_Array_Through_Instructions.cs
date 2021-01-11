public class Solution {
    private const int MOD = (int)1e9+7;
    private int[] c;    
    public int CreateSortedArray(int[] instructions) {
        c = new int[100001];
        int ret = 0, n = instructions.Length;
        for (int i = 0; i < n; i++)
        {
            ret = (ret + Math.Min(Get(instructions[i]-1), i-Get(instructions[i]))) % MOD;
            Update(instructions[i]);
        }

        return ret;
    }

    public void Update(int x)
    {
        while (x < 100001)
        {
            c[x]++;
            x += x & -x;
        }
    }

    public int Get(int x)
    {
        int ret = 0;
        while (x > 0)
        {
            ret += c[x];
            x -= x & -x;
        }
        return ret;
    }

    public int BruteForce(int[] instructions)
    {
        long ret = 0;
        var list = new List<int>();
        
        foreach (var num in instructions)
        {
            int l = 0, r = list.Count;
            
            while (l < r)
            {
                int m = (l + r) / 2;
                
                if (list[m] < num)
                    l = m+1;
                else
                    r = m;
            }
            
            int numOfLess = l;
            l = 0; 
            r = list.Count;
            
            while (l < r)
            {
                int m = (l + r) / 2;
                
                if (list[m] <= num)
                    l = m+1;
                else
                    r = m;
            }
            
            ret = (ret + Math.Min(numOfLess, list.Count - l)) % MOD;
            list.Insert(numOfLess, num);
        }
        
        return (int)ret;
    }
}