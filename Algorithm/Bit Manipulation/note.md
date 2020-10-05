### All even bits
The number 0xAAAAAAAA is a 32 bit number with all even bits set as 1 and all odd bits as 0.



### All odd bits
The number 0x55555555 is a 32 bit number with all odd bits set as 1 and all even bits as 0.

- [Power of Four](https://leetcode.com/problems/power-of-four/)


### Remove last bit
```cs
num & (num - 1)
```

- [Number of 1 Bits](https://leetcode.com/problems/number-of-1-bits/)
- [Counting Bits](https://leetcode.com/problems/counting-bits/)
- [Power of Four](https://leetcode.com/problems/power-of-four/)


### Extract last bit
```cs
// -num = ~num + 1
num & (-num)
```

- [Power of Two](https://leetcode.com/problems/power-of-two/)

### Single Number Series
```cs
int ans = 0;

foreach (int num in nums)
{
    ans ^= num;
}

return ans;
```

- [Single Number](https://leetcode.com/problems/single-number/)

### Missing Number
```cs
int ans = 0;

for (int i = 0; i < nums.Length; i++)
{
    ans ^= i;
    ans ^= nums[i];
}

return ans ^ nums.Length;
```

- [Missing Number](https://leetcode.com/problems/missing-number/)

### Hamming Weight

- [Number of 1 Bits](https://leetcode.com/problems/number-of-1-bits/)


