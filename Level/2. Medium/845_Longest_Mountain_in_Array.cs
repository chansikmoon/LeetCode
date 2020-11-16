public class Solution {
    public int LongestMountain(int[] A) {
        int up = 0, down = 0, ret = 0;
        
        for (int i = 1; i < A.Length; i++)
        {
            if (down > 0 && A[i - 1] < A[i] || A[i - 1] == A[i])
                up = down = 0;
            if (A[i - 1] < A[i])
                up++;
            if (A[i - 1] > A[i])
                down++;
            if (up > 0 && down > 0)
                ret = Math.Max(ret, up + down + 1);
        }
        
        return ret;
    }

    public int BruteForce(int[] A)
    {
        int ret = 0;
        
        for (int i = 0; i < A.Length; i++)
        {
            ret = Math.Max(ret, CheckLength(A, i));
        }
        
        return ret >= 3 ? ret : 0;
    }
    
    public int CheckLength(int[] A, int index)
    {
        int goingUp = 0, goingDown = 0;
        
        for (int i = index; i > 0; i--)
        {
            if (A[i - 1] >= A[i])
                break;
            goingUp++;
        }
        
        for (int i = index; i < A.Length - 1; i++)
        {
            if (A[i] <= A[i + 1])
                break;
            goingDown++;
        }
        
        return goingUp > 0 && goingDown > 0 ? goingUp + goingDown + 1 : 0;
    }
}