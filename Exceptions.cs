namespace IFDotNet;

/// <summary>
/// An exception that, when thrown, is caught by the game engine and displays an error message.
/// </summary>
/// <remarks>
///	Used in the case of non-fatal errors, like invalid command parameters.
/// </remarks>
public class ErrorMessageException : Exception
	
{
	
	/// 
	public ErrorMessageException() : base() {}
    /// 
    public ErrorMessageException(string msg) : base(msg) {}
    /// 
    public ErrorMessageException(Exception ex): base(ex.Message) {}
}
