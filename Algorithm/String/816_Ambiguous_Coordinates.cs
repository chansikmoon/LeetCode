public class Solution
{
    public IList<string> AmbiguousCoordinates(string s)
    {
        var trim = s.Substring(1, s.Length - 2);
        var coors = GetXYCoordinates(trim);

        var ret = new List<string>();

        foreach (var coor in coors)
        {
            var xs = GetPossibleCoordinates(coor[0]);
            var ys = GetPossibleCoordinates(coor[1]);

            foreach (var x in xs)
            {
                foreach (var y in ys)
                {
                    ret.Add(string.Format("({0}, {1})", x, y));
                }
            }
        }

        return ret;
    }

    private List<string> GetPossibleCoordinates(string s)
    {
        var ret = new List<string>();
        int n = s.Length;

        if (s[n - 1] == '0')
        {
            ret.Add(s);
            return ret;
        }

        for (int i = 1; i <= n; i++)
        {
            var sb = new StringBuilder(s);
            if (i < n)
                sb.Insert(i, '.');
            ret.Add(sb.ToString());

            if (s[0] == '0')
                break;
        }

        return ret;
    }

    private List<string[]> GetXYCoordinates(string s)
    {
        var ret = new List<string[]>();
        int n = s.Length;

        for (int xLen = 1; xLen < n; xLen++)
        {
            string x = s.Substring(0, xLen);
            string y = s.Substring(xLen, n - xLen);

            if (CheckFirstAndLastIndexIfZeros(x) || CheckFirstAndLastIndexIfZeros(y))
                continue;

            var newCoor = new string[] { x, y };
            ret.Add(newCoor);
        }

        return ret;
    }

    private bool CheckFirstAndLastIndexIfZeros(string s)
    {
        return s.Length > 1 && s[0] == '0' && s[0] == s[s.Length - 1];
    }
}