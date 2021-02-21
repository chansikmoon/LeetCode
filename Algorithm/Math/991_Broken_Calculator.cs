public class Solution {
    public int BrokenCalc(int X, int Y) {
        int count = 0;
        
        while (Y > X)
        {
            Y = (Y % 2 > 0) ? Y + 1 : Y / 2;
            count++;
        }
        
        return count + X - Y;
    }
}