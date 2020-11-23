public class Solution {
    public int UniqueMorseRepresentations(string[] words) {
        Dictionary<char, string> morseCodeMap = new Dictionary<char, string>()
        {
            {'a', ".-"}, {'b', "-..."}, {'c', "-.-."},
            {'d', "-.."}, {'e', "."}, {'f', "..-."},
            {'g', "--."}, {'h', "...."}, {'i', ".."},
            {'j', ".---"}, {'k', "-.-"}, {'l', ".-.."},
            {'m', "--"}, {'n', "-."}, {'o', "---"},
            {'p', ".--."}, {'q', "--.-"}, {'r', ".-."},
            {'s', "..."}, {'t', "-"}, {'u', "..-"},
            {'v', "...-"}, {'w', ".--"}, {'x', "-..-"},
            {'y', "-.--"}, {'z', "--.."}
        };
        
        HashSet<string> hashSet = new HashSet<string>();
        
        foreach (string word in words)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < word.Length; i++)
                sb.Append(morseCodeMap[word[i]]);
            
            Console.WriteLine(sb.ToString());
            hashSet.Add(sb.ToString());
        }
        
        return hashSet.Count;
    }
}