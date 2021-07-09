public class Solution {
    public void ReverseWords(char[] s) {
        Array.Reverse(s);
        
        for (int i = 0, j = 0; j <= s.Length; j++)   
        {
            if (j == s.Length || !char.IsLetter(s[j]))
            {
                Array.Reverse(s, i, j - i);
                i = j + 1;
            }
        }
    }
    
    private void Swap(char[] arr, int i, int j)
    {
        while (i < j)
        {
            char tmp = arr[i];
            arr[i] = arr[j];
            arr[j] = tmp;
            i++;
            j--;
        }
    }
}