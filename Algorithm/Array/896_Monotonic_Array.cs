public class Solution {
    public bool IsMonotonic(int[] A) {
        bool isIncrease = false, isDecrease = false;
        
        for (int i = 1; i < A.Length; i++)
        {
            if (A[i-1] == A[i]) continue;
            
            // increasing
            if (A[i-1] < A[i])
                isIncrease = true;
            
            // decreasing
            if (A[i-1] > A[i])
                isDecrease = true;
            
            if (!(isIncrease ^ isDecrease))
                return false;
        }
        
        return true;
    }

    // This solution is from lee215.
    private bool AnotherSolution(int[] A)
    {
        bool inc = true, dec = true;

        // Once it becomes false, it will not become true agian. 
        for (int i = 1; i < A.Length; i++)
        {
            inc &= A[i - 1] <= A[i];
            dec &= A[i - 1] >= A[i];
        }

        return inc || dec;
    }
}