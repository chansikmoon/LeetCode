public class Solution {
    public bool IsThree(int n) {
        int d = 2;
        
        for (int i = 2; i < n && d <= 3; i++)
        {
            d += (n % i == 0) ? 1 : 0;
        }
        
        return d == 3;
    }
}