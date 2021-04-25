public class Solution
{
    public int LongestBeautifulSubstring(string word)
    {
        int len = 1, count = 1, ret = 0;

        for (int i = 1; i < word.Length; i++)
        {
            int curr = word[i] - 'a';
            int prev = word[i - 1] - 'a';

            if (prev == curr)
                len++;
            else if (prev < curr)
            {
                len++;
                count++;
            }
            else
            {
                len = 1;
                count = 1;
            }

            if (count == 5)
                ret = Math.Max(ret, len);
        }

        return ret;
    }

    public int BruteForce(string word)
    {
        var map = new Dictionary<char, int>()
        {
            {'a', 1},
            {'e', 2},
            {'i', 3},
            {'o', 4},
            {'u', 5},
        };

        var visited = new bool[6];
        visited[0] = true;

        int ret = 0, minChar = 0;

        for (int l = 0, r = 0; r < word.Length; r++)
        {
            int currChar = map[word[r]];

            if (visited[currChar - 1] && minChar <= currChar)
            {
                minChar = currChar;
                visited[currChar] = true;

                if (currChar == 5)
                    ret = Math.Max(ret, r - l + 1);
            }
            else
            {
                l = currChar == 1 ? r : r + 1;
                minChar = 0;
                visited = new bool[6];
                visited[0] = true;
            }
        }

        return ret;
    }
}