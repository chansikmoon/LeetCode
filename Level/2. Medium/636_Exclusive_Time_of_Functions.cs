public class Solution {
    public int[] ExclusiveTime(int n, IList<string> logs)
    {
        Stack<Log> starts = new Stack<Log>();
        int[] ans = new int[n];

        foreach (string _log in logs)
        {
            Log log = new Log(_log);

            if (log.isStart)
                starts.Push(log);
            else
            {
                Log start = starts.Pop();
                int duration = log.time - start.time + 1;
                ans[start.id] += duration - start.subtractDuration;

                if (starts.Count > 0)
                    starts.Peek().subtractDuration += duration;
            }
        }

        return ans;
    }

    private class Log
    {
        public int id;
        public int time;
        public int subtractDuration;
        public bool isStart;

        public Log(string log)
        {
            string[] logFields = log.Split(':');
            this.id = ConvertStringToInt(logFields[0]);
            this.time = ConvertStringToInt(logFields[2]);
            this.isStart = logFields[1] == "start";
        }

        private int ConvertStringToInt(string str)
        {
            int retval = 0;

            for (int i = 0; i < str.Length; i++)
                retval = retval * 10 + (str[i] - '0');

            return retval;
        }
    }
}