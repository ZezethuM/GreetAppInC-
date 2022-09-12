using Npgsql;
using Dapper;
using System.Linq;
namespace greetFunction;

public class GreetWithBD : IGreet
{
    string connectionString = "Server=tiny.db.elephantsql.com;Port=5432;Database=yadlvyzc;UserId=yadlvyzc;Password=b2NCy-wd_58-hEenzMDVqUJA4VYlNWkJ";

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

    public void greetedFriends(string userName, int count)
    {
        userName = char.ToUpper(userName[0]) + userName.Substring(1);
        var connection = new NpgsqlConnection(connectionString);
        connection.Open();

        var parameter = new {UserName = userName};
        var sql = "SELECT count(*) FROM friends where friendsname = @UserName;";
        var result = connection.QueryFirst(sql, parameter);

        if(result.count == 1)
        {
            connection.Query(@"UPDATE friends SET count = count + 1 WHERE friendsname = @UserName", parameter);
        }
        else
        {
            connection.Execute(@"
            insert into 
                friends (FriendsName, Count)
            values 
                (@FriendsName, @Count);",
    
            new Friends()
            {
                FriendsName = userName,
                Count = count
            }
        );
        }
    connection.Close();
    }
    public Dictionary<string,int> printNames()
    {
        var connection = new NpgsqlConnection(connectionString);
        connection.Open();

        var selectAllNames = @"select * from friends";

        var listOfFriends = connection.Query<Friends>(selectAllNames);

     Dictionary<string, int> namesInDB = new Dictionary<string, int>();

        foreach (var people in listOfFriends)
        {
	        namesInDB.Add(people.FriendsName, people.Count);
        }

        return namesInDB;
    }

    public string printName( string friendName)
    {
        string z = "";
        var connection = new NpgsqlConnection(connectionString);
        connection.Open();
        var checkName  = @"select * from friends";
        var listedFriends = connection.Query<Friends>(checkName);

        foreach (var people in listedFriends)
        {
            if(people.FriendsName == friendName)
            {
                z = people.FriendsName + ":" + people.Count;
            }
        }
            return z;
    }
    public string Counter()
    {
        if(printNames().Count() == 0)
        {
            return "No friends have been greeted, list is empty!";
        }
        else 
        {
            return printNames().Count() + "," + "friend/s have been greeted.";
        }
    }
    public string Clear()
    {
        var connection = new NpgsqlConnection(connectionString);
        connection.Open();
        connection.Execute(@"truncate friends");
        return "All your friends have been cleared!!";
    }
    public string ClearAll( string name)
    {
        var connection = new NpgsqlConnection(connectionString);
        connection.Open();
        var checkName  = @"select * from friends";
        var listedFriends = connection.Query<Friends>(checkName);
        
     foreach (var people in listedFriends)
        {
            if(people.FriendsName == name)
            {
                connection.Query(@"DELETE from friends WHERE friendsname = @name", new {name =name});  
            }
        }
        return name + " " + "has been removed from list";
    }
}