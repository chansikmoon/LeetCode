public class Solution {
    public bool ValidMountainArray(int[] arr) {
        int n = arr.Length, i = 0, j = arr.Length - 1;

        while (i + 1 < n && arr[i] < arr[i + 1])
            i++;
        while (j > 0 && arr[j] < arr[j - 1])
            j--;
        return i > 0 && i == j && j < n - 1;
    }

    public bool BruteForce(int[] arr)
    {
        int i = 1, n = arr.Length;
        
        if (n < 3)
            return false;
        
        bool up = false;
        
        for (; i < n; i++)
        {
            if (arr[i - 1] >= arr[i])
                break;
            
            up = true;
        }
        
        if (i == n)
            return false;
        
        for (; i < n; i++)
        {
            if (arr[i - 1] <= arr[i])
                break;
        }
        
        return i == n && up;
    }
}