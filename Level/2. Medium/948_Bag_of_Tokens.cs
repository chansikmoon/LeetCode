public class Solution {
    // Time complexity: O(n log n) Array.Sort uses introSort
    // Space complexity: O(n) introSort space complexity is O(n)
    public int BagOfTokensScore(int[] tokens, int P) {
        // O(n log n)
        Array.Sort(tokens);
        int l = 0, r = tokens.Length - 1, score = 0, maxScore = 0;
        
        // O(n)
        while (l <= r)
        {
            if (P >= tokens[l])
            {
                P -= tokens[l++];
                score++;
                maxScore = Math.Max(score, maxScore);
            }
            else if (score > 0)
            {
                P += tokens[r--];
                score--;
            }
            else
                break;
        }
        
        return maxScore;
    }
}