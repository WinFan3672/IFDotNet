namespace IFDotNet;

/// <summary>
/// An individual Glulx instruction
/// </summary>
public class Instruction
{
	/// <summary>
	/// Opcode
	/// </summary>
	public uint OpCode {get; set; }

	/// <summary>
	/// Instruction arguments
	/// </summary>
	public object[] Arguments {get; set; }

	///
	public Instruction(OpCode opCode, params object[] args)
	{
		OpCode = (uint)opCode;
		Arguments = args;
	}
}
