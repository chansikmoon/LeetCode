public class Solution {
    public int MaxSumTwoNoOverlap(int[] A, int L, int M) {
        for (int i = 1; i < A.Length; i++)
            A[i] += A[i - 1];

        int res = A[L + M - 1], lLeft = A[L - 1], mLeft = A[M - 1];

        for (int i = L + M; i < A.Length; i++)
        {
            lLeft = Math.Max(lLeft, A[i - M] - A[i - L - M]);
            mLeft = Math.Max(mLeft, A[i - L] - A[i - L - M]);
            res = Math.Max(res, Math.Max(lLeft + A[i] - A[i - M], mLeft + A[i] - A[i - L]));
        }

        return res;
    }
}
/*

A: [0,6,5,2,2,5,1,9,4]  L: 1  M: 2

Prefix Sum
A: [0,6,11,13,15,20,21,30,34]
lLeft [0] ==> [0]
mLeft [6] ==> [0, 6]


lLeft [6]  ==> [6]  mLeft [11] ==> [6, 5]

lLeft + A[i] - A[i - M] 
6] + [5,2 ([0,6,5,2] - [0,6])

mLeft + A[i] - A[i - L]
6, 5] + [2 ([0,6,5,2] - [0,6,5])

*/