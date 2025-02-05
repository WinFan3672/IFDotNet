using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Dialogue tree
/// </summary>
public class DialogueTree : IEnumerable
{
    public List<DialogueTree> Choices { get; set; } = new List<DialogueTree>();
    public string VoiceLine { get; set; }

    public DialogueTree(string voiceLine)
    {
        VoiceLine = voiceLine;
    }

    public DialogueTree(string voiceLine, bool isPlayer, List<DialogueTree> choices)
    {
        VoiceLine = voiceLine;
        Choices = choices;
    }

    public void Run()
    {
        DialogueTree.Run(this);
    }

    public static void Run(DialogueTree tree)
    {
    }

    /// <inheritdoc/>
    public IEnumerator GetEnumerator()
    { 
        return Choices.GetEnumerator();
    }
}
