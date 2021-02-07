public class Solution {
    public string LargestMerge(string w1, string w2) {
        var sb = new StringBuilder();
        
        int i = 0, j = 0;
        
        while (i < w1.Length && j < w2.Length)
        {
            int char1 = w1[i] - 'a';
            int char2 = w2[j] - 'a';
            
            if (char1 < char2)
                sb.Append(w2[j++]);
            else if (char1 > char2)
                sb.Append(w1[i++]);
            else
            {
                var subWord1 = w1.Substring(i);
                var subWord2 = w2.Substring(j);
                // abaa, aaa: 1
                // aa, aaa: -1
                // aaa, aaa: 0
                var cmp = String.Compare(subWord1, subWord2);
                Console.WriteLine(String.Format("{0}, {1}: {2}", subWord1, subWord2, cmp));
                if (cmp > 0)
                    sb.Append(w1[i++]);
                else
                    sb.Append(w2[j++]);
            }
        }
        
        while (i < w1.Length)
            sb.Append(w1[i++]);
        while (j < w2.Length)
            sb.Append(w2[j++]);
        
        return sb.ToString();
    }

    // https://leetcode.com/problems/largest-merge-of-two-strings/discuss/1053549/JavaC%2B%2BPython-Easy-Greedy
    public string Beauty(string w1, string w2)
    {
        if (w1.Length == 0 || w2.Length == 0)
            return w1 + w2;
        
        if (String.Compare(w1, w2) > 0)
            return w1[0] + LargestMerge(w1.Substring(1), w2);

        return w2[0] + LargestMerge(w1, w2.Substring(1));
    }
}