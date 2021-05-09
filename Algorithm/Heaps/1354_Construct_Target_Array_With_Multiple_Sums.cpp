class Solution
{
    public:
    bool isPossible(vector<int>& target)
    {
        int n = target.size();
        long total = 0;
        // O(N)
        priority_queue<int> pq(target.begin(), target.end());
        for (int t : target)
            total += t;

        // log(MaxTarget)log(n)
        while (true)
        {
            int biggest = pq.top();
            pq.pop();
            total -= biggest;
            if (biggest == 1 || total == 1)
                return true;
            if (biggest < total || total == 0 || biggest % total == 0)
                return false;
            biggest %= total;
            total += biggest;
            pq.push(biggest);
        }

        return true;
    }
};