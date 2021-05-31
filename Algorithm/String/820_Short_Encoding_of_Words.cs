public class Solution {
    public int MinimumLengthEncoding(string[] words) {
        var _set = new HashSet<string>();
        
        foreach (var w in words)
            _set.Add(w);
        
        foreach (var w in words)
        {
            for (int i = 1; i < w.Length; i++)
                _set.Remove(w.Substring(i));
        }
        
        int ret = 0;
        
        foreach (var w in _set)
            ret += w.Length + 1;
        
        return ret;
    }

    public int MinimumLengthEncoding2(string[] words) {
        var list = new List<string>();
        
        for (int i = 0; i < words.Length; i++)
        {
            var charArr = words[i].ToCharArray();
            Array.Reverse(charArr);
            list.Add(new string(charArr));
            Console.WriteLine(new string(charArr));
        }
        
        var sorted = list.OrderBy(w => w).ToList();
        
        foreach (var a in sorted)
            Console.WriteLine(a);
        
        int ret = 0;
        
        /*
            ["time", "me", "bell"]
            em
            emit
            lleb

            ["p","grah","qwosp"]
            harg
            p
            psowq
        */

        // Math.Min() for "harg" and the next string is "p". Need to use min length.
        for (int i = 0; i < sorted.Count -1; i++)
        {
            ret += sorted[i] == sorted[i+1].Substring(0, Math.Min(sorted[i].Length, sorted[i+1].Length)) ? 0 : sorted[i].Length+1;
        }
        
        return ret + sorted[sorted.Count-1].Length + 1;
    }
}