namespace IFDotNet;
using System.IO;

public class Emitter
{
	private List<Instruction> code = new();
	private Dictionary<string, uint> labels = new();
	private MemoryStream stream;
	private BinaryWriter writer;

	///
	public Emitter()
	{
		stream = new();
		writer = new(stream);
	}

	/// <summary>
	/// Emit an instruction
	/// </summary>
	public void Emit(Instruction instruction)
	{
		code.Add(instruction);
	}

	/// <summary>
	/// Emit new instruction
	/// </summary>
	public void Emit(OpCode opCode, params object[] args)
	{
		Emit(new Instruction(opCode, args));
	}
}
