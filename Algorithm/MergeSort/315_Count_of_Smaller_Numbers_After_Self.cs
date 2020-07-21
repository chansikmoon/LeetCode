public class Solution {
    // You need to store the sorted index instead of sorting the nums. 
    // For example, [2,0,1] => [0,2][1] : [0, 2, 1] => [0, 1, 2]
    // count        [0,0,0] =>            [1, 0, 0] => [1, 1, 0] 
    
    public IList<int> CountSmaller(int[] nums)
    {
        int[] count = new int[nums.Length];
        int[] indexes = new int[nums.Length];
        for (int i = 0; i < nums.Length; i++)
            indexes[i] = i;
        MergeSort(nums, indexes, count, 0, nums.Length - 1);
        return count.ToList();
    }

    private void MergeSort(int[] nums, int[] indexes, int[] count, int start, int end)
    {
        if (end <= start)
            return;

        int mid = start + (end - start) / 2;
        MergeSort(nums, indexes, count, start, mid);
        MergeSort(nums, indexes, count, mid + 1, end);

        Merge(nums, indexes, count, start, end);
    }

    private void Merge(int[] nums, int[] indexes, int[] count, int start, int end)
    {
        int mid = start + (end - start) / 2, rightCount = 0, leftIndex = start, rightIndex = mid + 1, sortedIndex = 0;
        int[] sorted = new int[end - start + 1];

        while (leftIndex <= mid && rightIndex <= end)
        {
            if (nums[indexes[rightIndex]] < nums[indexes[leftIndex]])
            {
                sorted[sortedIndex] = indexes[rightIndex];
                rightCount++;
                rightIndex++;
            }
            else
            {
                sorted[sortedIndex] = indexes[leftIndex];
                count[indexes[leftIndex]] += rightCount;
                leftIndex++;
            }

            sortedIndex++;
        }

        while (leftIndex <= mid)
        {
            sorted[sortedIndex++] = indexes[leftIndex];
            count[indexes[leftIndex++]] += rightCount;
        }

        while (rightIndex <= end)
            sorted[sortedIndex++] = indexes[rightIndex++];

        for (int i = start; i <= end; i++)
            indexes[i] = sorted[i - start];
    }
}