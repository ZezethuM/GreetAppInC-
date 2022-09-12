namespace greetFunction;

public class Greet : IGreet
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
    
    public static  Dictionary<string, int> myFriends = new Dictionary<string, int>();
    public  int count = 1;
    public string Messages(string[] usercomm)
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

    public  void greetedFriends(string friends, int count)
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
    public  Dictionary<string,int> printNames()
    {
            return myFriends;
    }
    public string printName(string friendName)
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
    public string Counter()
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
    public  string Clear()
    {
        if(myFriends.Count() != 0)
        {
         myFriends.Clear();
        }
        return "All your friends have been cleared!!";
    }
     public  string ClearAll(string name)
    {
        if(myFriends.ContainsKey(name))
        {
            myFriends.Remove(name);
        }
        return name + " " + "has been removed from list";
    }
}