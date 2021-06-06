public class Solution {
    public string ReverseWords(string s) {
        var splits = s.Split(" ");
        
        var ret = new List<string>();
        
        foreach (var split in splits)
        {
            var arr = split.ToCharArray();
            
            for (int i = 0; i < arr.Length / 2; i++)
            {
                char tmp = arr[i];
                arr[i] = arr[arr.Length - i - 1];
                arr[arr.Length - i - 1] = tmp;
            }
            
            ret.Add(new string( arr ));
        }
        
        return string.Join(" ", ret);
    }
}