public class Solution {
    public int LadderLength(string beginWord, string endWord, IList<string> wordList) {
        var _set = wordList.ToHashSet();
        Queue<string> q = new Queue<string>();
        q.Enqueue(beginWord);
        int ret = 0;
        
        if (!_set.Contains(endWord))
            return ret;

        while (q.Count > 0)
        {
            int size = q.Count;
            while (size-- > 0)
            {
                var word = q.Dequeue();
                                
                if (word == endWord)
                    return ret + 1;
                
                var currWord = word.ToArray();
                
                for (int i = 0; i < currWord.Length; i++)
                {
                    char tmpCurrChar = currWord[i];
                    for (char ch = 'a'; ch <= 'z'; ch++)
                    {
                        if (ch != tmpCurrChar)
                        {
                            currWord[i] = ch;
                            string next = new string(currWord);
                        
                            if (_set.Contains(next))
                            {
                                q.Enqueue(next);
                                _set.Remove(next);
                            }
                        }
                    }
                    currWord[i] = tmpCurrChar;
                }
            }
            ret++;
        }
        
        return 0;
    }
}