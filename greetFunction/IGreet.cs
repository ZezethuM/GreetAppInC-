namespace greetFunction;

public interface IGreet
{
    public string Messages(string[] usercomm);
    public void greetedFriends(string friends, int count);
    public  Dictionary<string,int> printNames();

    public string printName(string friendName);
    public string Counter();
    public string Clear();
    public string ClearAll(string name);
}