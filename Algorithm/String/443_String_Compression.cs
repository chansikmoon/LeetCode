public class Solution {
    public int Compress(char[] chars) {
        int i = 0, j = 0, index = 0;
            
        for (; j < chars.Length; j++)
        {
            if (chars[i] == chars[j])
                continue;
            
            chars[index++] = chars[i];
            
            var st = ConvertIntToCharDigit(j - i);
            
            while (st.Count > 0)
                chars[index++] = (char)(st.Pop() + '0');
            
            i = j;
        }        
        
        var st1 = ConvertIntToCharDigit(j - i);
        
        chars[index++] = chars[i];
        
        while (st1.Count > 0)
            chars[index++] = (char)(st1.Pop() + '0');
        
        return index;
    }
    
    private Stack<int> ConvertIntToCharDigit(int num)
    {
        var st = new Stack<int>();
            
        while (num > 0)
        {
            st.Push(num % 10);
            num /= 10;
        }
        
        if (st.Count == 1 && st.Peek() == 1)
            return new Stack<int>();
        
        return st;
    }
}