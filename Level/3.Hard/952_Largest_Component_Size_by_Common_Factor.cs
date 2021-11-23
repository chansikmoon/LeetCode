public class Solution {
    public int LargestComponentSize(int[] nums) {
        int maxValue = nums.Max();
        var uf = new UnionFind(maxValue + 1);
        
        foreach (int num in nums)
        {
            for (int factor = 2; factor < (int)(Math.Sqrt(num)) + 1; factor++)
            {
                if (num % factor == 0)
                {
                    uf.Union(num, factor);
                    uf.Union(num, num / factor);
                }
            }
        }
        
        var map = new Dictionary<int, int>();
        int ret = 1;
        
        foreach (int num in nums)
        {
            var x = uf.Find(num);
            if (!map.ContainsKey(x))
                map.Add(x, 0);
            
            map[x]++;
            ret = Math.Max(ret, map[x]);
        }
        
        return ret;
    }
}

public class UnionFind {
    private int[] _parent { get; set; }
    private int[] _rank { get; set; }
    
    public UnionFind(int size)
    {
        _parent = new int[size];
        _rank = new int[size];
        
        for (int i = 0; i < size; i++)
        {
            _parent[i] = i;
            _rank[i] = 1;
        }
    }
    
    public int Find(int x)
    {
        while (x != _parent[x])
            return Find(_parent[x]);
        return x;
    }
    
    public void Union(int x, int y)
    {
        x = Find(x);
        y = Find(y);
        
        if (x == y)
            return;
        
        if (_rank[x] < _rank[y])
        {
            int tmp = y;
            y = x;
            x = tmp;
        }
        
        _rank[x] += _rank[y];
        _parent[y] = x;
    }
}