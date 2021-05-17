public class FindSumPairs
{
    private int[] nums1;
    private int[] nums2;
    private Dictionary<int, int> Freq;

    public FindSumPairs(int[] nums1, int[] nums2)
    {
        this.nums1 = new int[nums1.Length];
        this.nums2 = new int[nums2.Length];
        Freq = new Dictionary<int, int>();

        for (int i = 0; i < nums1.Length; i++)
            this.nums1[i] = nums1[i];

        for (int i = 0; i < nums2.Length; i++)
        {
            this.nums2[i] = nums2[i];
            if (!Freq.ContainsKey(nums2[i]))
                Freq.Add(nums2[i], 0);
            Freq[nums2[i]]++;
        }
    }

    public void Add(int index, int val)
    {
        Freq[nums2[index]]--;
        nums2[index] += val;
        if (!Freq.ContainsKey(nums2[index]))
            Freq.Add(nums2[index], 0);
        Freq[nums2[index]]++;
    }

    public int Count(int tot)
    {
        int ret = 0;
        foreach (int num in nums1)
        {
            if (Freq.ContainsKey(tot - num))
                ret += Freq[tot - num];
        }

        return ret;
    }
}

/**
 * Your FindSumPairs object will be instantiated and called as such:
 * FindSumPairs obj = new FindSumPairs(nums1, nums2);
 * obj.Add(index,val);
 * int param_2 = obj.Count(tot);
 */