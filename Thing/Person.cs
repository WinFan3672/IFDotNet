using System.Globalization;

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
    public DialogueTree? Tree { get; set; }

    /// <inheritdoc/>
    public override bool Grab()
    {
        return false;
    }

    /// 
    public Person(string name, string description = "It's rude to stare.", DialogueTree? tree = null) : base(name, description)
    {
        Tree = tree;
    }
}
