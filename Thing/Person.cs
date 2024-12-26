namespace IFDotNet;

public class Person : Thing
{
	public List<Thing> Inventory = new();

	public Person(string name, string description = "It's rude to stare.") : base(name, description)
	{
	}
}
