public class Solution {
    public int HammingDistance(int x, int y) {
        int hd = x ^ y, count = 0;

        while (hd > 0)
        {
            hd = hd & (hd - 1);
            count++;
        }
        
        return count;
    }
}