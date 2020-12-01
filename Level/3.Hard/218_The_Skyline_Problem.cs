public class Solution {
  // https://leetcode.com/problems/the-skyline-problem/discuss/395923/JavaScript-Easy-and-Straightforward-with-picture-illustrations
  public IList<IList<int>> GetSkyline(int[][] buildings) {
        List<IList<int>> ret = new List<IList<int>>();
        int n = buildings.Length;
        if (n == 0)
            return ret;
        
        HashSet<int> xPoints = new HashSet<int>();
        foreach (int[] b in buildings)
        {
            xPoints.Add(b[0]);
            xPoints.Add(b[1]);
        }
        
        var sortedXPoints = xPoints.OrderBy(x => x).ToList();
        ret.Add(new List<int>(){-1, 0});
        
        foreach (int x in sortedXPoints)
        {
            int i = 0, height = 0;
            while (i < n && buildings[i][0] <= x)
            {
                if (buildings[i][1] > x)
                    height = Math.Max(height, buildings[i][2]);
                i++;
            }
            
            if (ret[ret.Count - 1][1] == height)
                continue;
            
            ret.Add(new List<int>() {x, height});
        }
        
        ret.RemoveAt(0);
        
        return ret;
    }

    // Out of Memory Exception
    public IList<IList<int>> BruteForce(int[][] buildings) {
        List<IList<int>> ret = new List<IList<int>>();
        int n = buildings.Length;
        if (n == 0)
            return ret;
        
        int landscapeRange = buildings[n - 1][1];
        int[] arr = new int[landscapeRange + 1];
        
        foreach (int[] b in buildings)
        {
            for (int i = b[0]; i < b[1]; i++)
                arr[i] = Math.Max(arr[i], b[2]);
        }
        
        if (arr[0] > 0)
            ret.Add(new List<int> {0, arr[0]});
        
        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i - 1] != arr[i])
                ret.Add(new List<int>(){i, arr[i]});
        }
        
        return ret;
    }
}