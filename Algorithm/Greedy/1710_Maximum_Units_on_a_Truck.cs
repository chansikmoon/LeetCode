public class Solution {
    public int MaximumUnits(int[][] boxTypes, int truckSize) {
        var sortedBoxTypes = boxTypes.OrderByDescending(x => x[1]).ToArray();
        int ret = 0;

        foreach (var sbt in sortedBoxTypes)
        {
            if (truckSize <= 0)
                break;
            
            int maximumSize = Math.Min(truckSize, sbt[0]);
            
            ret += sbt[1] * maximumSize;
            
            truckSize -= maximumSize;
        }
        
        return ret;
    }
}