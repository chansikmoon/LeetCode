public class Solution
{
    public string Multiply(string num1, string num2)
    {
        int n1 = num1.Length, n2 = num2.Length;

        var products = new int[n1 + n2];

        for (int i = n1 - 1; i >= 0; i--)
        {
            int v1 = num1[i] - '0';
            for (int j = n2 - 1; j >= 0; j--)
            {
                int v2 = num2[j] - '0';
                products[i + j + 1] += v1 * v2;
            }
        }

        for (int i = products.Length - 1, carry = 0; i > 0; i--)
        {
            products[i - 1] += products[i] / 10;
            products[i] %= 10;
        }

        var sb = new StringBuilder();

        if (products[0] > 0)
            sb.Append(products[0]);

        for (int i = 1; i < products.Length; i++)
        {
            if (products[i] == 0 && sb.Length == 0)
                continue;

            sb.Append(products[i]);
        }

        return sb.Length == 0 ? "0" : sb.ToString();
    }
}