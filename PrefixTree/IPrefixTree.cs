namespace PrefixTree;
public interface IPrefixTree
{
    void Insert(string word);
    bool Search(string word);
    bool StartsWith(string prefix);
    bool Delete(string word);
}
