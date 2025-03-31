namespace IFDotNet;

internal class Header
{
	private byte[] magicNumber = { 0x47, 0x6c, 0x75, 0x6c };
	private byte[] version = { 0x00, 0x03, 0x01, 0x03 };

	private byte[] ramStart;
	private byte[] extStart;
	private byte[] endMem;
	private byte[] stackSize;
	private byte[] startFunc;
	private byte[] decodingTbl;
	private byte[] checksum;

	internal Header(byte[] ramStart, byte[] extStart, byte[] endMem, byte[] stackSize, byte[] startFunc, byte[] decodingTbl, byte[] checksum)
	{
		this.ramStart = ramStart;
		this.extStart = extStart;
		this.endMem = endMem;
		this.stackSize = stackSize;
		this.startFunc = startFunc;
		this.decodingTbl = decodingTbl;
		this.checksum = checksum;
	}

	/// <summary>
	/// Generate header
	/// </summary>
	internal byte[] Generate()
	{
		MemoryStream stream = new();
		BinaryWriter writer = new(stream);

		writer.Write(magicNumber);
		writer.Write(version);
		writer.Write(ramStart);
		writer.Write(extStart);
		writer.Write(endMem);
		writer.Write(stackSize);
		writer.Write(startFunc);
		writer.Write(decodingTbl);
		writer.Write(checksum);

		return stream.ToArray();
	}
}
