namespace IFDotNet;

public class ErrorMessageException : Exception
{
	public ErrorMessageException() : base() {}
	public ErrorMessageException(string msg) : base(msg) {}
	public ErrorMessageException(Exception ex): base(ex.Message) {}
}
