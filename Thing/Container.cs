using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using IFDotNet;

/// <summary>
/// A container that contains things
/// </summary>
public class Container : Thing
{
    /// <summary>
    /// If the object can be picked up
    /// </summary>
    public bool CanPickUp { get; private set; }
    /// <summary>
    /// Things the container contains
    /// </summary>
    public List<Thing> Things { get; } = new List<Thing>();
    /// 
    public Container(string name, string description, bool canPickUp = true) : base(name, description)
    {
        CanPickUp = canPickUp;
        CheckGrab += () => { return CanPickUp; };
    }

    /// <inheritdoc/>

    /// <summary>
    /// Adds a thing to the container.
    /// </summary>
    public void Add(Thing thing)
    {
        Things.Add(thing);
    }
}