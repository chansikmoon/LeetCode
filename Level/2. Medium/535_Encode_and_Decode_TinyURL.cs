public class Codec
{
    Dictionary<string, string> map = new Dictionary<string, string>();
    string s = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

    public string encode(string longUrl)
    {
        var shortUrl = IntToString(map.Count);
        map.Add(shortUrl, longUrl);
        return shortUrl;
    }
    string IntToString(int n)
    {
        var sb = new StringBuilder();
        while (n != 0)
        {
            sb.Append(s[n % 62]);
            n /= 10;
        }
        return sb.ToString();
    }
    // Decodes a shortened URL to its original URL.
    public string decode(string shortUrl)
    {
        return map[shortUrl];
    }
}

// Your Codec object will be instantiated and called as such:
// Codec codec = new Codec();
// codec.decode(codec.encode(url));