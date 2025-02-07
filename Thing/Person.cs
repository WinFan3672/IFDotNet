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
    /// <summary>
    /// Dialogue tree for this particular person.
    /// </summary>
    public DialogueTree? Tree { get; set; }

    /// <inheritdoc/>

    /// 
    public Person(string name, string description = "It's rude to stare.", DialogueTree? tree = null) : base(name, description)
    {
        Tree = tree;
        CheckGrab += () => { return false; };
    }
}
