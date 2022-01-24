public class Solution {
    public bool DetectCapitalUse(string word) {
        // All Upper
        // All Lower
        // First letter is upper && remain letters are lower
        return word.IsAllUpper() || word.IsAllLower() || (word.Substring(0, 1).IsAllUpper() && word.Substring(1).IsAllLower());
    }
}

public static class StringHelper
{
    public static bool IsAllUpper(this string str)
    {
        foreach (var c in str)
        {
            if (!char.IsUpper(c))
                return false;
        }
        
        return true;
    }
    
    public static bool IsAllLower(this string str)
    {
        foreach (var c in str)
        {
            if (!char.IsLower(c))
                return false;
        }
        
        return true;
    }
}