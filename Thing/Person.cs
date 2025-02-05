namespace IFDotNet;

/// <summary>
/// A person in the world
/// </summary>
public class Person : Thing
{
	/// <summary>
	/// Person's inventory
	/// </summary>
	public List<Thing> Inventory = new();


    /// 
    public Person(string name, string description = "It's rude to stare.") : base(name, description)
	{
	}
}
