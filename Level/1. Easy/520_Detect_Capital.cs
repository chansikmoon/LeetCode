public class Solution {
    public bool DetectCapitalUse(string word) {
        return CheckAllUpper(word) || CheckAllLower(word) || CheckFirstLetterUpperAndAllLower(word);
    }
    
    private bool CheckAllUpper(string word)
    {
        foreach (char c in word)
        {
            if (!Char.IsUpper(c))
                return false;
        }
        
        return true;
    }
    
    private bool CheckAllLower(string word)
    {
        foreach (char c in word)
        {
            if (!Char.IsLower(c))
                return false;
        }
        
        return true;
    }
    
    private bool CheckFirstLetterUpperAndAllLower(string word)
    {
        return CheckAllUpper(word.Substring(0, 1)) && CheckAllLower(word.Substring(1));
    }
}