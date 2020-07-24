public class Solution {
    public int[] SingleNumber(int[] nums) {
        int bitMask = 0;
        
        foreach (int num in nums)
            bitMask ^= num;
        
        int rightMost = bitMask & (-bitMask), x = 0;
        
        foreach (int num in nums)
            if ((rightMost & num) != 0)
                x ^= num;
        
        return new int[]{x , bitMask ^ x};
    }
    
    private int[] BruteForce(int[] nums)
    {
        Dictionary<int, int> map = new Dictionary<int, int>();
        
        foreach (int num in nums)
        {
            if (!map.ContainsKey(num))
                map.Add(num, 0);
            
            map[num]++;
        }
        
        return map.Where(x => x.Value == 1).Select(x => x.Key).ToArray();
    }
}
