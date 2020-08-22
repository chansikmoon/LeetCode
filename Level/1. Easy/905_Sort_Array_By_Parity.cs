public class Solution {
    public int[] SortArrayByParity(int[] A) {
        return NTimeSpace(A);
        // even even -> i++
        // even odd -> i++ j--        
        // odd even -> swap i++ j--
        // odd odd  -> j--
        
        int i = 0, j = A.Length - 1;
        
        while (i < j)
        {
            if (A[i] % 2 == 0)
            {
                if (A[j] % 2 == 0) i++;
                else
                {
                    i++;
                    j--;
                }
            }
            else
            {
                if (A[j] % 2 == 0)
                {
                    int tmp = A[i];
                    A[i] = A[j];
                    A[j] = tmp;
                }
                else
                    j--;
            }
        }
        
        return A;
    }
    
    private int[] NTimeSpace(int[] A)
    {
        int l = 0, r = A.Length - 1;
        int[] ret = new int[A.Length];
        
        for (int i = 0; i < A.Length; i++)
        {
            if (A[i] % 2 == 0)
                ret[l++] = A[i];
            else
                ret[r--] = A[i];
        }
        
        return ret;
    }
}