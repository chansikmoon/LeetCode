public class NumArray {
    private int[] tree;
    private int[] nums;
    
    public NumArray(int[] nums) {
        tree = new int[nums.Length + 1];
        this.nums = nums;
        
        for (int i = 1; i < tree.Length; i++)
            tree[i] = nums[i - 1];
        
        for (int i = 1; i < tree.Length; i++)
        {
            int next = i + LSB(i);
            
            if (next < tree.Length) tree[next] += tree[i];
        }
    }
    
    private int LSB(int bit)
    {
        return bit & -bit;
    }
    
    public void Update(int index, int val) {
        int diff = val - nums[index];
        nums[index] = val;
        
        index += 1;
        
        while (index < tree.Length)
        {
            tree[index] += diff;
            index += LSB(index);
        }
    }
    
    public int SumRange(int left, int right) {
        return GetPreSum(right + 1) - GetPreSum(left);
    }
    
    private int GetPreSum(int index)
    {
        int ret = 0;
        
        while (index != 0)
        {
            ret += tree[index];
            index &= ~LSB(index);
        }
        
        return ret;
    }
}

/**
 * Your NumArray object will be instantiated and called as such:
 * NumArray obj = new NumArray(nums);
 * obj.Update(index,val);
 * int param_2 = obj.SumRange(left,right);
 */