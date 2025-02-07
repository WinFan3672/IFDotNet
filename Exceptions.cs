namespace IFDotNet;

/// <summary>
/// An exception that, when thrown, is caught by the game engine and displays an error message.
/// </summary>
/// <remarks>
///	Used in the case of non-fatal errors, like invalid command parameters.
/// </remarks>
public class ErrorMessageException : Exception
{
    /// <summary>Custom error message</summary>
    public ErrorMessageException(string msg) : base(msg) {}
    /// <summary>Inherit the message of an <see cref="Exception"/></summary>
    public ErrorMessageException(Exception ex): base(ex.Message) {}
}

/// <summary>
/// Exception thrown when the player dies.
/// </summary>
public class PlayerDeathException : Exception
{
    public PlayerDeathException() : base(string.Empty) {}
    /// <param name="message">Death message</param>
    public PlayerDeathException(string message) : base(message) { }
}