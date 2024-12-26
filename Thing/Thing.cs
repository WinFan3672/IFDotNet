namespace IFDotNet;

public class Thing
{
	public string Name {get; private set; }
	public string Description {get; private set; }

	public Thing(string name, string description)
	{
		Name = name;
		Description = description;
	}
}
