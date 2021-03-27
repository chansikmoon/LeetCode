public class Solution
{
    public IList<string> WordSubsets(string[] A, string[] B)
    {
        var count = new int[26];

        foreach (var b in B)
        {
            var tmp = Count(b);
            for (int i = 0; i < 26; i++)
                count[i] = Math.Max(count[i], tmp[i]);
        }

        var ret = new List<string>();

        foreach (var a in A)
        {
            var tmp = Count(a);
            int i = 0;
            for (; i < 26; i++)
            {
                if (tmp[i] < count[i])
                    break;
            }

            if (i == 26)
                ret.Add(a);
        }

        return ret;
    }

    private int[] Count(string str)
    {
        var ret = new int[26];
        for (int i = 0; i < str.Length; i++)
            ret[str[i] - 'a']++;
        return ret;
    }

    // Passed 45/55 cases but TLE at case 46.
    private List<string> BruteForce(string[] A, string[] B)
    {
        var aArr = new List<int[]>();
        var bArr = new List<int[]>();

        foreach (var a in A)
        {
            var aTmp = new int[26];

            for (int i = 0; i < a.Length; i++)
                aTmp[a[i] - 'a']++;

            aArr.Add(aTmp);
        }

        foreach (var b in B)
        {
            var bTmp = new int[26];

            for (int i = 0; i < b.Length; i++)
                bTmp[b[i] - 'a']++;

            bArr.Add(bTmp);
        }

        var ret = new List<string>();
        int index = 0;

        foreach (var a in aArr)
        {
            var str = A[index++];
            int targetCount = B.Length;
            int actualCount = 0;

            foreach (var b in bArr)
            {
                int targetC = 0;
                int actualC = 0;
                for (int i = 0; i < 26; i++)
                {
                    if (b[i] == 0)
                        continue;

                    targetC++;

                    if (a[i] >= b[i])
                        actualC++;
                }

                if (targetC == actualC)
                    actualCount++;
            }

            if (targetCount == actualCount)
                ret.Add(str);
        }

        return ret;
    }
}