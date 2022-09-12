using greetFunction;
namespace greet_test;

public class UnitTest1
{
    [Fact]
    public void ShouldBeAbleToGreetDifferentPeopleInAllLanguages()
    {
        Greet greets = new Greet();
        Assert.Equal("Hello, Zeze", greets.Messages(new string[]{"greet" , "Zeze", "English"}));
        Assert.Equal("Molo, Avile", greets.Messages(new string[]{"greet", "Avile", "Isixhosa"}));
        Assert.Equal("Bonjour, Phumza", greets.Messages(new string[] {"greet", "Phumza", "French"}));
        Assert.Equal("Heita, Khazimla", greets.Messages(new string[] {"greet", "Khazimla"}));
    }
     [Fact]
    public void ShouldBeAbleToStoreNamesAndReturnThem()
    {
        Greet greets = new Greet();

        greets.greetedFriends("Zeze",1 );
        greets.greetedFriends("Avile",1);
        greets.greetedFriends("Phumza", 1);
        greets.greetedFriends("Khazimla", 1);

        Dictionary<string, int> myPeople = new Dictionary<string, int>(){{"Zeze", 1}, {"Avile", 1}, {"Phumza", 1}, {"Khazimla", 1}};
        Assert.Equal(myPeople, greets.printNames()); 
    }

    [Fact]

    public void ShouldBeAbleToPrintANameThatWasGreeted()
    {
        Greet greets = new Greet();

        greets.greetedFriends( "Andre",1);
        greets.greetedFriends("Yanga", 1);

        Dictionary<string, int> printNam = new Dictionary<string, int>(){{"Andre", 1}, {"Yanga", 1}};
        Assert.Equal("Andre:1", greets.printName("Andre"));
        Assert.Equal("Yanga:1", greets.printName("Yanga"));
        
    }
    [Fact]
    public void ShouldReturnAMassageThatNameIsNotOnListIfUserSearchANameThatHasNotBeenGreeted()
    {
        Greet greets = new Greet();

        greets.Messages(new string[]{"greet", "Yanga", "Isixhosa"});

        Dictionary<string, int> printNam = new Dictionary<string, int>(){{"Yanga", 1}};
        
        Assert.Equal("Your friend is not on the list please do greet them.", greets.printName("Andre"));
    }
    [Fact]
    public void ShouldReturnMessageThatListIsEmptyIfNoNamesHaveBeenGreeted()
    {
        Greet greets = new Greet();

       Dictionary<string, int> printNams = new Dictionary<string, int>(){};

       Assert.Equal("No friends have been greeted, list is empty!", greets.Counter());
    }
    [Fact]
    public void ShouldBeAbleCountTheNumberOfNamesInTheListAndReturnTheyAre()
    {
        Greet greets = new Greet();

        greets.greetedFriends("Zeze",1 );
        greets.greetedFriends("Avile",1);
        greets.greetedFriends("Phumza", 1);
        greets.greetedFriends("Khazimla", 1);

        Dictionary<string, int> myPeople = new Dictionary<string, int>(){{"Zeze", 1}, {"Avile", 1}, {"Phumza", 1}, {"Khazumla", 1}};
        Assert.Equal(myPeople.Count() + "," + "friend/s have been greeted.", greets.Counter());
    }
    [Fact]
    public void ShouldBeAbleToClearANameFromTheList()
    {
        Greet greets = new Greet();

        greets.Messages(new string[]{"greet", "Yanga", "Isixhosa"});
        greets.Messages(new string[]{"greet", "Anthony", "Isixhosa"});

        Dictionary<string, int> clearName = new Dictionary<string, int>(){{"Yanga", 1},{"Anthony", 1}};
        Assert.Equal("Anthony has been removed from list", greets.ClearAll("Anthony"));
    }
    [Fact]
    public void SHouldBeABleToClearAllTheNamesInTheList()
    {
        Greet greets = new Greet();

        greets.Messages(new string[]{"greet", "Siphe", "French"});
        greets.Messages(new string[]{"greet", "Cara", "Isixhosa"});

        Dictionary<string, int> clearAll = new Dictionary<string, int>(){{"Siphe", 1},{"Cara", 1}};

        Assert.Equal("All your friends have been cleared!!", greets.Clear());
    }
}