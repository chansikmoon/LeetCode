public class Solution {
    public bool ValidSquare(int[] p1, int[] p2, int[] p3, int[] p4) {
        if (Distance(p1, p2) == 0 || 
            Distance(p2, p3) == 0 || 
            Distance(p3, p4) == 0 || 
            Distance(p4, p1) == 0)
            return false;
        
        return (Distance(p1, p2) == Distance(p3, p4) && 
                Distance(p1, p3) == Distance(p2, p4) && 
                Distance(p1, p4) == Distance(p2, p3) && 
                (Distance(p1, p2) == Distance(p1, p3) || 
                 Distance(p1, p2) == Distance(p1, p4) || 
                 Distance(p1, p3) == Distance(p1, p4))
               );
    }
    
    private int Distance(int[] p1, int[] p2)
    {
        int x = p1[0] - p2[0];
        int y = p1[1] - p2[1];
        return x * x + y * y;
    }
}