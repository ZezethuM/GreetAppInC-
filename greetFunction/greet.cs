namespace greetFunction;

public class Greet
{
    public string Name
    {
        get;
        set;
    } = string.Empty;
    public string Language
    {
        get;
        set;
    } = string.Empty;
    
    public static Dictionary<string, int> myFriends = new Dictionary<string, int>();
    public static int count = 1;
    public static string Messages(string[] usercomm)
    {
        string message = "";
        if(usercomm.Length == 3)
        {
            if(usercomm[2] == "English" && usercomm[0] == "greet")
            {
                message = "Hello, " + usercomm[1];
            }
            else if(usercomm[2] == "French" && usercomm[0] == "greet")
            {
                message = "Bonjour, " + usercomm[1];
            }
            else if(usercomm[2] == "Isixhosa" && usercomm[0] == "greet")
            {
                message =  "Molo, " + usercomm[1];
            }
        }
        else 
        {
            message = "Heita, " + usercomm[1];
        }
        return message;
    }

    public static void greetedFriends(string friends, int count)
    { 
         if(myFriends.ContainsKey(friends))
        {
            myFriends[friends]++;
        }
        else
        {
            myFriends.Add(friends, count);
        }
    }
    public static Dictionary<string,int> printNames(Dictionary<string,int> myFriends)
    {
            return myFriends;
    }
    public static string printName(Dictionary<string,int> myFriends, string friendName)
    { 
         if(myFriends.ContainsKey(friendName))
         {
           return friendName + ":" +  myFriends[friendName]; 
         }
        else
        {
            return "Your friend is not on the list please do greet them.";
        }    
    }
    public static string Counter(Dictionary<string, int> myFriends)
    {
        if(myFriends.Count() == 0)
        {
            return "No friends have been greeted, list is empty!";
        }
        else 
        {
            return myFriends.Count() + "," + "friend/s have been greeted.";
        }
    }
    public static string Clear(Dictionary<string, int> myFriends)
    {
        if(myFriends.Count() != 0)
        {
         myFriends.Clear();
        }
        return "All your friends have been cleared!!";
    }
     public static string ClearAll(Dictionary<string, int> myFriend, string name)
    {
        if(myFriend.ContainsKey(name))
        {
            myFriends.Remove(name);
        }
        return name + " " + "has been removed from list";
    }
}