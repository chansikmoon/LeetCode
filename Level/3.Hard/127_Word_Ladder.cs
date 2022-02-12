public class Solution {
    public int LadderLength(string beginWord, string endWord, IList<string> wordList) {
        var wordSet = wordList.ToHashSet();
        
        if (wordSet.Add(endWord))
            return 0;
        
        var q = new Queue<string>();
        q.Enqueue(beginWord);
        
        int ret = 0;
        
        while (q.Count > 0) 
        {
            int size = q.Count;
            
            while (size-- > 0)
            {
                var currWord = q.Dequeue();
            
                if (currWord == endWord)
                    return ret + 1;

                var arr = currWord.ToCharArray();    
                
                for (int i = 0; i < arr.Length; i++)
                {
                    var tmp = arr[i];
                    
                    for (char ch = 'a'; ch <= 'z'; ch++)
                    {
                        if (ch != tmp)
                        {
                            arr[i] = ch;
                            var nextWord = new string(arr);
                            
                            if (wordSet.Contains(nextWord))
                            {
                                q.Enqueue(nextWord);
                                wordSet.Remove(nextWord);
                            }
                        }
                    }
                    
                    arr[i] = tmp;
                }
            }
            
            ret++;
        }
        
        return 0;
    }
}