public class Solution
{
    public int MaximumPopulation(int[][] logs)
    {
        // line sweep
        var arr = new int[2051];
        foreach (var log in logs)
        {
            arr[log[0]]++;
            arr[log[1]]--;
        }

        int max = 0, year = 0;
        for (int i = 1950; i < 2051; i++)
        {
            arr[i] += arr[i - 1];
            if (arr[i] > max)
            {
                max = arr[i];
                year = i;
            }
        }

        return year;
    }

    private int bruteforce(int[][] logs)
    {
        int n = logs.Length;
        var births = new List<int>();
        var deaths = new List<int>();

        foreach (var log in logs)
        {
            births.Add(log[0]);
            deaths.Add(log[1]);
        }

        births.Sort();
        deaths.Sort();

        int year = 0;
        int max = 0;
        for (int i = 0; i < n; i++)
        {
            int tmp = 0;
            int tmpYear = 0;
            for (int j = i; j < n; j++)
            {

                if (births[j] < deaths[i])
                {
                    tmp++;
                    tmpYear = births[j];
                }
            }

            if (tmp > max)
            {
                max = tmp;
                year = tmpYear;
            }
        }


        return year;
    }
}