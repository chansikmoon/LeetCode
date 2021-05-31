public class Solution
{
    public int[] MovesToStamp(string stamp, string target)
    {
        var stampArr = stamp.ToCharArray();
        var targetArr = target.ToCharArray();
        var visited = new bool[target.Length];
        var ret = new List<int>();
        int hash = 0;

        while (hash < target.Length)
        {
            bool hasModified = false;

            for (int i = 0; i <= target.Length - stamp.Length; i++)
            {
                if (!visited[i] && IsValid(stampArr, targetArr, i))
                {
                    hash += GetNumOfModifiedCharsAndModifyArr(targetArr, i, stamp.Length);
                    hasModified = true;
                    visited[i] = true;
                    ret.Add(i);

                    if (hash == target.Length)
                        break;
                }
            }

            if (!hasModified)
                return new int[0];
        }

        ret.Reverse();
        return ret.ToArray();
    }

    private bool IsValid(char[] stamp, char[] target, int index)
    {
        for (int i = 0; i < stamp.Length; i++)
        {
            if (target[index + i] != '#' && stamp[i] != target[index + i])
                return false;
        }

        return true;
    }

    private int GetNumOfModifiedCharsAndModifyArr(char[] target, int index, int n)
    {
        int ret = 0;

        for (int i = 0; i < n; i++)
        {
            if (target[index + i] != '#')
            {
                target[index + i] = '#';
                ret++;
            }
        }

        return ret;
    }
}