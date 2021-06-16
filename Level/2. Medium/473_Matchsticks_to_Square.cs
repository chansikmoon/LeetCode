public class Solution {
    public bool Makesquare(int[] matchsticks) {
        int sum = matchsticks.Sum();
        if (sum % 4 != 0)
            return false;
        
        return DFS(matchsticks, new int[4], 0, sum / 4);
    }
    
    private bool DFS(int[] m, int[] sides, int index, int target)
    {
        if (index >= m.Length)
            return sides[0] == target && sides[1] == target && sides[2] == target;
        
        for (int i = 0; i < 4; i++)
        {
            if (sides[i] + m[index] > target)
                continue;
            
            sides[i] += m[index]; 
            
            if (DFS(m, sides, index + 1, target))return true;
            
            sides[i] -= m[index];
        }
        
        return false;
    }
}