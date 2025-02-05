namespace IFDotNet;

/// <summary>
/// An object in the world
/// </summary>
public class Thing
{
	/// <summary>
	/// Object name
	/// </summary>
	public string Name {get; private set; }
	/// <summary>
	/// Object description
	/// </summary>
	/// <remarks>The player will see this when using <see cref="LookMove"/></remarks>
	public string Description {get; private set; }

	/// 
	public Thing(string name, string description)
	{
		Name = name;
		Description = description;
	}
}
