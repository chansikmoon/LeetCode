public class Solution {
    public int MinSwaps(int[] data) {
        int totalOnes = data.Sum();
        int countOnes = 0, maxOnes = 0, l = 0, r = 0;
        
        while (r < data.Length)
        {
            countOnes += data[r++];
            while (r - l > totalOnes)
                countOnes -= data[l++];
            
            maxOnes = Math.Max(countOnes, maxOnes);
        }
        
        return totalOnes - maxOnes;
    }
}