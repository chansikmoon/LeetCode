public class Solution {
    public Random rand;
    public int[] areaArr;
    public int[][] rects;
    public int totalArea;

    public Solution(int[][] rects) {
        rand = new Random();
        areaArr = new int[rects.Length];
        this.rects = rects.Select(x => x.ToArray()).ToArray();
        totalArea = 0;
        int index = 0;
        
        foreach (int[] rect in rects)
        {
            totalArea += GetArea(rect);
            areaArr[index++] = totalArea;
        }
    }
    
    public int GetArea(int[] rect)
    {
        return (rect[2] - rect[0] + 1) * (rect[3] - rect[1] + 1);
    }
    
    public int[] Pick() {
        int key = rand.Next(totalArea + 1), l = 0, r = rects.Length - 1;
        
        while (l < r)
        {
            int m = l + (r - l) / 2;
            if (key >= areaArr[m]) l = m + 1;
            else r = m;
        }
        
        int[] rect = rects[l];
        
        return new int[] {rect[0] + rand.Next(rect[2] - rect[0] + 1), rect[1] + rand.Next(rect[3] - rect[1] + 1)};   
    }
}

/**
 * Your Solution object will be instantiated and called as such:
 * Solution obj = new Solution(rects);
 * int[] param_1 = obj.Pick();
 */