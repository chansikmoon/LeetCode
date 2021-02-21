public class Solution {
    public int[] MinOperations(string boxes) {
        var ret = new int[boxes.Length];
        
        for (int i = 0, count = 0, sum = 0; i < boxes.Length; i++)
        {
            ret[i] += sum;
            count += boxes[i] == '1' ? 1 : 0;
            sum += count;
        }
        
        for (int i = boxes.Length - 1, count = 0, sum = 0; i >= 0; i--)
        {
            ret[i] += sum;
            count += boxes[i] == '1' ? 1 : 0;
            sum += count;
        }
        
        return ret;
    }
    
    private int[] BruteForce(string boxes)
    {
        var ret = new int[boxes.Length];
        
        for (int i = 0; i < boxes.Length; i++)
        {
            for (int j = 0; j < boxes.Length; j++)
            {
                if (boxes[j] == '1')
                    ret[i] += Math.Abs(j-i);
            }
        }
        
        return ret;
    }
}