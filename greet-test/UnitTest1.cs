using greetFunction;
namespace greet_test;

public class UnitTest1
{
    [Fact]
    public void ShouldBeAbleToGreetDifferentPeopleInAllLanguages()
    {
        Assert.Equal("Hello, Zeze", Greet.Messages(new string[]{"greet" , "Zeze", "English"}));
        Assert.Equal("Molo, Avile", Greet.Messages(new string[]{"greet", "Avile", "Isixhosa"}));
        Assert.Equal("Bonjour, Phumza", Greet.Messages(new string[] {"greet", "Phumza", "French"}));
        Assert.Equal("Heita, Khazimla", Greet.Messages(new string[] {"greet", "Khazimla"}));
    }
     [Fact]
    public void ShouldBeAbleToStoreNamesAndReturnThem()
    {
        Greet.Messages(new string[]{"greet" , "Zeze", "English"});
        Greet.Messages(new string[]{"greet", "Avile", "Isixhosa"});
        Greet.Messages(new string[]{"greet", "Phumza", "French"});
        Greet.Messages(new string[]{"greet", "Khazimla"});

        Dictionary<string, int> myPeople = new Dictionary<string, int>(){{"Zeze", 1}, {"Avile", 1}, {"Phumza", 1}, {"Khazumla", 1}};
        Assert.Equal(myPeople, Greet.printNames(myPeople));
    }

    [Fact]

    public void ShouldBeAbleToPrintANameThatWasGreeted()
    {
        Greet.Messages(new string[]{"greet" , "Andre", "English"});
        Greet.Messages(new string[]{"greet", "Yanga", "Isixhosa"});

        Dictionary<string, int> printNam = new Dictionary<string, int>(){{"Andre", 1}, {"Yanga", 1}};
        
        Assert.Equal("Andre:1", Greet.printName(printNam, "Andre"));
        Assert.Equal("Yanga:1", Greet.printName(printNam, "Yanga"));
        
    }
    [Fact]
    public void ShouldReturnAMassageThatNameIsNotOnListIfUserSearchANameThatHasNotBeenGreeted()
    {
        Greet.Messages(new string[]{"greet", "Yanga", "Isixhosa"});

        Dictionary<string, int> printNam = new Dictionary<string, int>(){{"Yanga", 1}};
        
        Assert.Equal("Your friend is not on the list please do greet them.", Greet.printName(printNam, "Andre"));
    }
    [Fact]
    public void ShouldReturnMessageThatListIsEmptyIfNoNamesHaveBeenGreeted()
    {
       Dictionary<string, int> printNams = new Dictionary<string, int>(){};

       Assert.Equal("No friends have been greeted, list is empty!", Greet.Counter(printNams));
    }
    [Fact]
    public void ShouldBeAbleCountTheNumberOfNamesInTheListAndReturnTheyAre()
    {
        Greet.Messages(new string[]{"greet", "Yanga", "Isixhosa"});
        Greet.Messages(new string[]{"greet", "Anthony", "Isixhosa"});
        Greet.Messages(new string[]{"greet", "Lukhayo", "Isixhosa"});
        Greet.Messages(new string[]{"greet", "Kamva", "Isixhosa"});

        Dictionary<string, int> printNam = new Dictionary<string, int>(){{"Yanga", 1},{"Anthony", 1},{"Lukhanyo", 1},{"Kamva", 1}};
        Assert.Equal(printNam.Count() + "," + "friend/s have been greeted.", Greet.Counter(printNam));
    }
    [Fact]
    public void ShouldBeAbleToClearANameFromTheList()
    {
        Greet.Messages(new string[]{"greet", "Yanga", "Isixhosa"});
        Greet.Messages(new string[]{"greet", "Anthony", "Isixhosa"});

        Dictionary<string, int> clearName = new Dictionary<string, int>(){{"Yanga", 1},{"Anthony", 1}};
        Assert.Equal("Anthony has been removed from list", Greet.ClearAll(clearName, "Anthony"));
    }
    [Fact]
    public void SHouldBeABleToClearAllTheNamesInTheList()
    {
        Greet.Messages(new string[]{"greet", "Siphe", "French"});
        Greet.Messages(new string[]{"greet", "Cara", "Isixhosa"});

        Dictionary<string, int> clearAll = new Dictionary<string, int>(){{"Siphe", 1},{"Cara", 1}};

        Assert.Equal("All your friends have been cleared!!", Greet.Clear(clearAll));
    }
}