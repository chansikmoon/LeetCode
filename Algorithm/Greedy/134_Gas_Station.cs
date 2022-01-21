public class Solution {
    public int CanCompleteCircuit(int[] gas, int[] cost) {
        int total = 0, curr = 0, initial = 0;
        
        for (int i = 0; i < gas.Length; i++)
        {
            total += gas[i] - cost[i];
            curr += gas[i] - cost[i];
            
            if (curr < 0)
            {
                initial = i + 1;
                curr = 0;
            }
        }
        
        return total >= 0 ? initial : -1;
    }
}