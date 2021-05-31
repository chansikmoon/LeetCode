public class Solution
{
    public IList<IList<string>> FindDuplicate(string[] paths)
    {
        var map = new Dictionary<string, List<string>>();

        foreach (var path in paths)
        {
            var parts = path.Split(' ');
            var root = parts[0];

            for (int i = 1; i < parts.Length; i++)
            {
                var info = parts[i].Split('(');
                var fileName = info[0];
                var content = info[1];

                var dir = new StringBuilder(root + "/");
                dir.Append(fileName);

                if (!map.ContainsKey(content))
                    map.Add(content, new List<string>());

                map[content].Add(dir.ToString());
            }
        }

        var ret = new List<IList<string>>();

        foreach (var kvp in map)
        {
            if (kvp.Value.Count <= 1)
                continue;

            var list = new List<string>();
            foreach (var path in kvp.Value)
                list.Add(path);

            ret.Add(list);
        }

        return ret;
    }
}