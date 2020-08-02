public class Solution {
    public int MaxScore(int[] cardPoints, int k) {
        int n = cardPoints.Length, total = 0, answer = 0, window = 0;
        
        for (int i = 0, j = n - k; i < n; i++)
        {
            total += cardPoints[i];
            
            if (j-- > 0)
                window += cardPoints[i];
        }
        
        answer = total - window;
        
        for (int i = 0; i < k; i++)
        {
            window -= cardPoints[i];
            window += cardPoints[i + n - k];
            answer = Math.Max(answer, total - window);
        }

        return answer;
    }
}