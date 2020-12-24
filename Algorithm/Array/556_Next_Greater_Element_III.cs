public class Solution {
    public int NextGreaterElement(int n) {
        var arr = n.ToString().ToCharArray();
        
        int i = arr.Length - 2;
        
        while (i >= 0 && arr[i] >= arr[i + 1])
            i--;
        
        if (i < 0)
            return -1;
        
        int j = arr.Length - 1;
        
        while (i < j && arr[i] >= arr[j])
            j--;
        
        Swap(arr, i, j);
        Reverse(arr, i + 1, arr.Length - 1);
        
        long ret = ConvertArrToInt(arr);
        return ret >= (long) Int32.MaxValue ? -1 : (int) ret;;
    }
    
    private void Swap(char[] arr, int i, int j)
    {
        char c = arr[i];
        arr[i] = arr[j];
        arr[j] = c;
    }
    
    private void Reverse(char[] arr, int i, int j)
    {
        while (i < j)
            Swap(arr, i++, j--);
    }
    
    private long ConvertArrToInt(char[] arr)
    {
        long ret = 0;
        
        foreach (var c in arr)
        {
            ret = ret * 10 + (c - '0');
        }
        
        return ret;
    }        
}