public class Solution {
    public long NumberOfWeeks(int[] milestones) {
        Array.Sort(milestones);
        int n = milestones.Length;
        
        long ret = 0;
        
        for (int i = 0; i < n - 1; i++)
            ret += milestones[i];
        
        ret += Math.Min(milestones[n - 1], ret + 1);
        
        return ret;
    }
}