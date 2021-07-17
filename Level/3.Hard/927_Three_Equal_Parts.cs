public class Solution {
    public int[] ThreeEqualParts(int[] arr) {        
        int numOfOnes = 0, n = arr.Length;
        var oneMap = new Dictionary<int, int>();
        
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == 1)
                numOfOnes++;
            
            if (numOfOnes > 0 && !oneMap.ContainsKey(numOfOnes))
                oneMap.Add(numOfOnes, i);
        }
        
        if (numOfOnes == 0)
            return new int[] { 0, n - 1 };
        
        int onesPerPart = numOfOnes / 3;
        if (onesPerPart == 0)
            return new int[] { -1, -1 };
        
        int leftPtr = oneMap[1], midPtr = oneMap[onesPerPart + 1], rightPtr = oneMap[onesPerPart * 2 + 1];
        
        while (rightPtr < n)
        {
            if (arr[leftPtr] == arr[midPtr] && arr[midPtr] == arr[rightPtr])
            {
                leftPtr++;
                midPtr++;
                rightPtr++;
            }
            else
                return new int[] { -1, -1 };
        }
        
        return new int[] { leftPtr - 1, midPtr };
    }
}