public class Solution {
    public bool BuddyStrings(string A, string B) {
        // if the length is different, no way to swap to match
        if (A.Length != B.Length) return false;
        
        // if A and B are the same, check if A has duplicate letters. 
        if (A == B)
        {
            HashSet<char> s = new HashSet<char>();

            foreach (char c in A)
                s.Add(c);
            
            // A: aaabc
            // s: a,b,c
            // can swap a's
            return s.Count < A.Length;
        }
        
        List<int> diff = new List<int>();
        
        for (int i = 0; i < A.Length; i++)
        {
            if (A[i] != B[i])
                diff.Add(i);
        }
        
        return diff.Count == 2 && A[diff[0]] == B[diff[1]] && A[diff[1]] == B[diff[0]];        
    }
}