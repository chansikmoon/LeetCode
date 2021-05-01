public class Solution
{
    public IList<IList<string>> AccountsMerge(IList<IList<string>> accounts)
    {
        int n = accounts.Count;

        var indexToNames = new Dictionary<int, string>();
        var indexToEmails = new Dictionary<int, List<string>>();
        var emailToIndexAdjList = new Dictionary<string, List<int>>();

        for (int i = 0; i < n; i++)
        {
            var account = accounts[i];
            var name = account[0];
            var emails = account.Skip(1).ToList();
            indexToNames.Add(i, name);
            indexToEmails.Add(i, emails);

            foreach (var email in emails)
            {
                if (!emailToIndexAdjList.ContainsKey(email))
                    emailToIndexAdjList.Add(email, new List<int>());

                emailToIndexAdjList[email].Add(i);
            }
        }

        var visited = new bool[n];
        var ret = new List<IList<string>>();

        for (int i = 0; i < n; i++)
        {
            if (visited[i])
                continue;

            var disjoint = new HashSet<string>();
            DFS(indexToEmails, emailToIndexAdjList, visited, disjoint, i);
            var tmp = disjoint.OrderBy(x => x, StringComparer.Ordinal).ToList();
            tmp.Insert(0, indexToNames[i]);
            ret.Add(tmp);
        }

        return ret;
    }

    private void DFS(
        Dictionary<int, List<string>> indexToEmails,
        Dictionary<string, List<int>> emailToIndexAdjList,
        bool[] visited,
        HashSet<string> disjoint,
        int curr)
    {
        if (visited[curr])
            return;

        visited[curr] = true;

        foreach (var email in indexToEmails[curr])
        {
            disjoint.Add(email);

            foreach (int next in emailToIndexAdjList[email])
                DFS(indexToEmails, emailToIndexAdjList, visited, disjoint, next);
        }
    }
}