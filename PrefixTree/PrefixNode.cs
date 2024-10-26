namespace PrefixTree;
public class PrefixNode
{
    public Dictionary<char, PrefixNode> Children { get; set; } = [];
    public int Count { get; set; }
    public bool IsWord { get; set; }
}