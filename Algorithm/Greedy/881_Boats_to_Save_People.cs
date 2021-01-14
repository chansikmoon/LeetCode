public class Solution {
    public int NumRescueBoats(int[] people, int limit) {
        Array.Sort(people);
        int i = 0, j = 0;
        for (i = 0, j = people.Length - 1; i <= j; j--)
        {
            if (people[i] + people[j] <= limit)
                i++;
        }
        
        return people.Length - 1 - j;
    }
}