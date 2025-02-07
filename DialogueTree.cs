using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;

/// <summary>
/// Dialogue tree
/// </summary>
public class DialogueTree : IEnumerable
{
    /// <summary>
    /// Dialogue options
    /// </summary>
    public List<DialogueTree> Choices { get; private set; } = new List<DialogueTree>();
    /// <summary>
    /// What the character says
    /// </summary>
    public string VoiceLine { get; set; }
    /// <summary>
    /// Who says it
    /// </summary>
    public string? VoiceActor { get; set; }

    private static Random rand = new Random();

    /// 
    public DialogueTree(string voiceLine)
    {
        VoiceLine = voiceLine;
    }

    /// 
    public DialogueTree(string voiceLine, string voiceActor)
    { 
        VoiceLine = voiceLine;
        VoiceActor = voiceActor;
    }

    /// 
    public DialogueTree(string voiceLine, List<DialogueTree> choices)
    {
        VoiceLine = voiceLine;
        Choices = choices;
    }

    /// 
    public DialogueTree(string voiceLine, string voiceActor, List<DialogueTree> choices)
    {
        VoiceLine = voiceLine;
        VoiceActor = voiceActor;
        Choices = choices;
    }

    /// <summary>
    /// Executes this dialouge tree.
    /// </summary>
    public void Run()
    {
        DialogueTree.Run(this);
    }

    /// <summary>
    /// Executes a dialogue tree.
    /// </summary>
    /// <param name="tree">Dialogue tree to execute.</param>
    public static void Run(DialogueTree tree)
    {
        if (tree.Choices.Count > 0)
        {
            // Create a SelectionPrompt and get the player to choose a dialogue option
            var selPrompt = new SelectionPrompt<DialogueTree>().Title($"{tree.VoiceActor}: {tree.VoiceLine}").AddChoices(tree.Choices);
            var sel = AnsiConsole.Prompt(selPrompt);
            // Pick a random response
            Run(sel.Pick());
        }
        else
        {
            Console.WriteLine(tree);
        }

}

/// <inheritdoc/>
public IEnumerator GetEnumerator()
    { 
        return Choices.GetEnumerator();
    }

    /// <summary>
    /// Add a choice.
    /// </summary>
    /// <param name="choice">Choice to add</param>
    public void Add(DialogueTree choice)
    { 
        Choices.Add(choice);
    }

    /// <summary>
    /// Picks a random choice.
    /// </summary>
    /// <returns>Random choice</returns>
    public DialogueTree Pick()
    {
        return Choices[rand.Next(Choices.Count)];
    }

    /// <inheritdoc/>
    public override string ToString()
    {
        if (VoiceActor == null)
        {
            return VoiceLine;
        }
        else
        {
            return $"{VoiceActor}: {VoiceLine}";
        }
    }

    /// <summary>
    /// Finds a dialogue choice by its voiceline.
    /// </summary>
    /// <param name="voiceLine">Voice line to search</param>
    /// <returns>The dialogue choice if <c>voiceLine</c> is an exact match.</returns>
    public DialogueTree? Get(string voiceLine)
    {
        foreach (var choice in Choices)
            if (choice.VoiceLine == voiceLine)
                return choice;
        return null;
    }
}