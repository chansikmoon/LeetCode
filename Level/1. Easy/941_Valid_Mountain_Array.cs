public class Solution {
    public bool ValidMountainArray(int[] arr) {
        int n = arr.Length, i = 0, j = arr.Length - 1;

        while (i + 1 < n && arr[i] < arr[i + 1])
            i++;
        while (j > 0 && arr[j] < arr[j - 1])
            j--;
        return i > 0 && i == j && j < n - 1;
    }

    public bool AnotherSolution(int[] arr) {
        if (arr.Length < 3)
            return false;
        
        int inc = 1;
        for (; inc < arr.Length; inc++)
        {
            if (arr[inc - 1] >= arr[inc])
                break;
        }
        
        int dec = arr.Length - 1;
        for (; dec > 0; dec--)
        {
            if (arr[dec - 1] <= arr[dec])
                break;
        }
        
        return inc != 1 && dec != arr.Length -1 && dec + 1 == inc;
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