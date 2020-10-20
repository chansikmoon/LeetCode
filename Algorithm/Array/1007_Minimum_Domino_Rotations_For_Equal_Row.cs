public class Solution {
    public int MinDominoRotations(int[] A, int[] B) {
        int ret = Math.Min(GetMinRotations(A[0], A, B), GetMinRotations(B[0], A, B));
        return ret == Int32.MaxValue ? -1 : ret;
    }
    
    public int GetMinRotations(int target, int[] A, int[] B)
    {
        int countA = 0, countB = 0;
        
        for (int i = 0; i < A.Length; i++)
        {
            // if both array don't have target value, then return maximum value
            if (A[i] != target && B[i] != target)
                return Int32.MaxValue;
            
            // At least one of the arrays has the target value
            if (A[i] != B[i])
            {
                // A[0] == target, then countA++
                if (B[i] == target)
                    countA++;
                else
                    countB++;
            }
        }
        
        return Math.Min(countA, countB);
    }

    public int BruteForceSolution(int[] A, int[] B)
    {
        int ret = 0, originalFirstElement = 0, swappedFirstElement = 1, target = A[0];
        
        for (int i = 1; i < A.Length; i++)
        {
            if (A[i] != target && B[i] != target)
            {
                originalFirstElement = Int32.MaxValue;
                swappedFirstElement = Int32.MaxValue;
                break;
            }
            
            if (A[i] != B[i])
            {
                if (B[i] == target)
                    originalFirstElement++;
                else
                    swappedFirstElement++;    
            }
        }
        
        ret = Math.Min(originalFirstElement, swappedFirstElement);
        originalFirstElement = 0;
        swappedFirstElement = 1;
        target = B[0];
        
        for (int i = 1; i < B.Length; i++)
        {
            if (B[i] != target && A[i] != target)
            {
                originalFirstElement = Int32.MaxValue;
                swappedFirstElement = Int32.MaxValue;
                break;
            }
            
            if (A[i] != B[i])
            {
                if (A[i] == target)
                    originalFirstElement++;
                else
                    swappedFirstElement++;
            }
        }
        
        ret = Math.Min(ret, Math.Min(originalFirstElement, swappedFirstElement));
        
        return ret == Int32.MaxValue ? -1 : ret;
    }
}