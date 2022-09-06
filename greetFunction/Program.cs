using greetFunction;
Greet test = new Greet();
string userCommand = "";
string Name = "";
string Language = "";
while(userCommand != "exit")
{
Console.WriteLine("Welcome to the Greetings Application.");
Console.WriteLine("Enter: help to see commands you can use on the App");
Console.WriteLine("***********************************");
Console.Write("Please enter a command to: ");
userCommand = Console.ReadLine();
string[] users = userCommand.Split(" ");
int counter = 1;

if(users[0] == "greet")
{
    Name = users[1];
    Console.WriteLine(Greet.Messages(users));
    Greet.greetedFriends(Name, counter);
    Console.WriteLine("****************************************");
}

else if(userCommand == "greeted")
{
    foreach(var key in Greet.printNames(Greet.myFriends))
    {
        // Console.WriteLine(Greet.printNames(Greet.myFriends));
        Console.WriteLine(key.Key + ":" +  key.Value);
    }
    if(Greet.myFriends.Count() == 0)
    {
        Console.WriteLine("There are no friends in the list");
    }
}
else if(users[0] == "greeted")
{
    Name = users[1];

    if(Greet.myFriends.ContainsKey(Name))
    {
        Console.WriteLine(Name + ":" + Greet.myFriends[Name]);

        Console.WriteLine("*********************************");
    }
}
else if(userCommand == "counter")
{
    Console.WriteLine(Greet.Counter(Greet.myFriends));
    Console.WriteLine("*********************************");
}
else if(userCommand == "clear")
{   
    Console.WriteLine(Greet.Clear(Greet.myFriends));
    // Greet.myFriends.Clear();
    // Console.WriteLine("All your friends have been cleared!!");
    Console.WriteLine("*********************************");
}
 else if(users[0] == "clear")
{
    if(Greet.myFriends.Count() != 0)
    {
        Name = users[1];
        Console.WriteLine(Greet.ClearAll(Greet.myFriends, Name));
        Console.WriteLine("Below are the remaining names in the list: ");
        foreach(var key in Greet.myFriends)
         {
            Console.WriteLine(key.Key + ":" +  key.Value);
            Console.WriteLine("*********************************");
         }
    }
}
else if(userCommand == "help")
{
    Console.WriteLine("Languages you can greet in are : Isixhosa, English, French and default is Kasi slang");
    Console.WriteLine("Enter: greet [name of friend] language- to greet a friend");
    Console.WriteLine("Enter: greeted - to see names greeted a friend");
    Console.WriteLine("Enter: greeted [name of friend] - to see if a friend has been greeted");
    Console.WriteLine("Enter: clear - to remove all the greeted friends");
    Console.WriteLine("Enter: clear [name of friend] - to remove a name from the greeted names");
    Console.WriteLine("Enter: exit -To exit the Application");
    Console.WriteLine("****************************************************");
}
}
Console.WriteLine("Thank you for using the App Bye!!");