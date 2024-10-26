namespace PrefixTree;

public class PrefixTree : IPrefixTree
{
    private readonly PrefixNode _root = new();

    public void Insert(string word)
    {
        if (Search(word)) return;
        var current = _root;
        foreach (char c in word)
        {
            if (!current.Children.TryGetValue(c, out PrefixNode? value))
            {
                value = new();
                current.Children[c] = value;
            }
            current = value;
            current.Count++;
        }
        current.IsWord = true;
    }

    public bool Search(string word)
    {
        var current = _root;
        foreach (char c in word)
        {
            if (!current.Children.TryGetValue(c, out PrefixNode? value))
            {
                return false;
            }
            if (value.Count == 0) return false;
            current = value;
        }
        return current.IsWord;
    }

    public bool StartsWith(string prefix)
    {
        var current = _root;
        foreach (char c in prefix)
        {
            if (!current.Children.TryGetValue(c, out PrefixNode? value))
            {
                return false;
            }
            current = value;
        }
        return true;
    }
    public bool Delete(string word)
    {
        if (!Search(word)) return false;
        var current = _root;
        foreach (char c in word)
        {
            if (!current.Children.TryGetValue(c, out PrefixNode? value))
            {
                return false;
            }
            value.Count--;
            current = value;
        }
        current.IsWord = false;
        return true;
    }

}
