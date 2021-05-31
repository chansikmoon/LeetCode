public class Solution
{
    public int LeastBricks(IList<IList<int>> wall)
    {
        var freq = new Dictionary<int, int>();
        int n = wall.Count;

        for (int i = 0; i < n; i++)
        {
            int width = 0;

            for (int j = 0; j < wall[i].Count - 1; j++)
            {
                width += wall[i][j];

                if (!freq.ContainsKey(width))
                    freq.Add(width, 0);

                freq[width]++;
            }
        }

        return n - (freq.Count > 0 ? freq.Values.Max() : 0);
    }
}