namespace IFDotNet;

/// <summary>
/// Glulx opcode
/// </summary>
///
/// <remarks>
/// This is the most convoluted enum I've ever written,
/// in no small part because the Glulx documentation is all over the place.
/// For one, its documentation separates instructions in ways completely irrelevant to the opcodes.
/// </remarks>
///
/// <seealso href="https://www.eblong.com/zarf/glulx/Glulx-Spec.html" />
public enum OpCode : uint
{
	/* B A S I C  A R I T H M E T I C */

	/// <summary>
	/// No operation
	/// </summary>
	///
	/// <remarks>
	/// Truncates if necessary
	/// </remarks>
	Nop = 0x0,

	/// <summary>
	/// Integer addition
	/// </summary>
	Add = 0x10,

	/// <summary>
	/// Integer subtraction
	/// </summary>
	Sub = 0x11,

	/// <summary>
	/// Integer multiplication
	/// </summary>
	///
	/// <remarks>
	/// Truncates if necessary
	/// </remarks>
	Mul = 0x12,

	/// <summary>
	/// Integer division
	/// </summary>
	///
	/// <remarks>
	/// Signed integer division
	/// </remarks>
	Div = 0x13,

	/// <summary>
	/// Integer modulus
	/// </summary>
	///
	/// <remarks>
	/// Remainder of signed integer division
	/// </remarks>
	Mod = 0x14,

	/// <summary>
	/// Negative of integer
	/// </summary>
	Neg = 0x15,

	/// <summary>
	/// Bitwise AND
	/// </summary>
	BitAnd = 0x18,

	/// <summary>
	/// Bitwise OR
	/// </summary>
	BitOr = 0x19,

	/// <summary>
	/// Bitwise XOR
	/// </summary>
	BitXor = 0x1a,

	/// <summary>
	/// Bitwise NOT
	/// </summary>
	BitNot = 0x1b,

	/// <summary>
	/// Left bit shift
	/// </summary>
	///
	/// <remarks>
	/// Bottom bits filled with zeroes
	/// </remarks>
	ShiftL = 0x1c,

	/// <summary>
	/// Shift right bit, filling top bits with top bit of original value
	/// </summary>
	SShiftR = 0x1d,
	/// <summary>
	/// Shift right bit, filling top bits with zero
	/// </summary>
	///
	/// <remarks>
	/// If value >= 32, result is always zero
	/// </remarks>
	UShiftR = 0x1e,

	/* J U M P I N G */

	/// <summary>
	/// Jump unconditionally
	/// </summary>
	Jump = 0x20,

	/// <summary>
	/// Jump if zero
	/// </summary>
	Jz = 0x22,

	/// <summary>
	/// Jump if not zero
	/// </summary>
	Jnz = 0x23,

	/// <summary>
	/// Jump if equal
	/// </summary>
	Jeq = 0x24,

	/// <summary>
	/// Jump if not equal
	/// </summary>
	Jne = 0x25,

	/// <summary>
	/// Jump if less than, signed int
	/// </summary>
	Jlt = 0x26,

	/// <summary>
	/// Jump if greater than or equal to, signed int
	/// </summary>
	Jge = 0x27,

	/// <summary>
	/// Jump if greater than, signed int
	/// </summary>
	Jgt = 0x28,

	/// <summary>
	/// Jump if less than or equal to, signed int
	/// </summary>
	Jle = 0x29,

	/// <summary>
	/// Jump if less than, unsigned int
	/// </summary>
	JltU = 0x2a,
	
	/// <summary>
	/// Jump if greater than or equal, unsigned int
	/// </summary>
	JgeU = 0x2b,

	/// <summary>
	/// Jump if greater than, unsigned int
	/// </summary>
	JgtU = 0x2c,

	/// <summary>
	/// Jump less than or equal, unsigned int
	/// </summary>
	JleU = 0x2d,

	/* C A L L I N G */

	/// <summary>
	/// Call function
	/// </summary>
	Call = 0x30,

	/// <summary>
	/// Return from current function w/ return value
	/// </summary>
	///
	/// <remarks>
	/// If top function, Glulx execution ends
	/// </remarks>
	///
	/// <remarks>
	/// Branch opcodes can return 0/1 instead of branching
	/// </remarks>
	Return = 0x31,

	/// <summary>
	/// Generates catch token, used to jump back from throw opcode
	/// </summary>
	Catch = 0x32,

	/// <summary>
	/// Jump back to previous catch opcode
	/// </summary>
	Throw = 0x33,

	/// <summary>
	/// Call and pass result to caller
	/// </summary>
	TailCall = 0x34,

	/* M O V I N G  D A T A */

	/// <summary>
	/// Basic copy
	/// </summary>
	Copy =  0x40,

	/// <summary>
	/// Copy 16-bit
	/// </summary>
	CopyS = 0x41,

	/// <summary>
	/// Copy 8-bit
	/// </summary>
	CopyB = 0x42,

	/// <summary>
	/// Sign-extend 16-bit
	/// </summary>
	SexS = 0x44,

	/// <summary>
	/// Sign-extend 8-bit
	/// </summary>
	SexB = 0x45,

	/* A R R A Y  D A T A */

	/// <summary>
	/// Load an int from an array
	/// </summary>
	ALoad = 0x48,

	/// <summary>
	/// Load a 16-bit value from an array
	/// </summary>
	ALoadS = 0x49,
	
	/// <summary>
	/// Load a byte from an array
	/// </summary>
	ALoadB = 0x4a,
	
	/// <summary>
	/// Load a bit from an array
	/// </summary>
	ALoadBit = 0x4b,

	/// <summary>
	/// Store an integer in an array
	/// </summary>
	AStore = 0x4c,

	/// <summary>
	/// Store a 16-bit value in an array
	/// </summary>
	AStoreS = 0x4d,

	/// <summary>
	/// Store a byte in an array
	/// </summary>
	AStoreB = 0x4e,

	/// <summary>
	/// Store a bit in an array
	/// </summary>
	AStoreBit = 0x4f,

	/* S T A C K */

	/// <summary>
	/// Store stack count
	/// </summary>
	StkCount = 0x50,

	/// <summary>
	/// Peek at stack without popping
	/// </summary>
	StkPeek = 0x51,

	/// <summary>
	/// Swap top two values in stack
	/// </summary>
	StkSwap = 0x52,

	/// <summary>
	/// Rotate top two values on stack
	/// </summary>
	StkRoll = 0x53,

	/// <summary>
	/// Peek at stack values
	/// </summary>
	StkCopy = 0x54,

	/* S T R E A M I N G */

	/// <summary>
	/// Send character to current stream
	/// </summary>
	StreamChar = 0x70,

	/// <summary>
	/// Send decimal (in ASCII) to current stream
	/// </summary>
	StreamNum = 0x71,

	/// <summary>
	/// Send string to current stream
	/// </summary>
	SreamStr = 0x72,

	/// <summary>
	/// Send unicode character to current stream
	/// </summary>
	StreamUniChar = 0x73,

	/*  M I S C E L L A N E O U S */

	/// <summary>
	/// Gestalt separator
	/// </summary>
	Gestalt = 0x100,

	/// <summary>
	/// "Interrupt execution to do something interpreter-specific with L1. If the interpreter has nothing in mind, it should halt with a visible error message."
	/// </summary>
	DebugTrap = 0x101,

	/// <summary>
	/// Get memory map size
	/// </summary>
	GetMemSize = 0x102,

	/// <summary>
	/// Set memory map size
	/// </summary>
	SetMemSize = 0x103,

	/// <summary>
	/// Jump to memory address
	/// </summary>
	JumpAbs = 0x104,

	/// <summary>
	/// Random number generator
	/// </summary>
	Random = 0x110,

	/// <summary>
	/// Set RNG seed
	/// </summary>
	SetRandom = 0x111,

	/* G A M E  S T A T E */

	/// <summary>
	/// Quit game
	/// </summary>
	Quit = 0x120,

	/// <summary>
	/// Perform sanity check on game file
	/// </summary>
	///
	/// <remarks>
	/// Sets S1 to 0 if tests pass, and 1 if they do not
	/// </remarks>
	///
	/// <remarks>
	/// Most interpreters do this automatically
	/// </remarks>
	Verify = 0x121,

	/// <summary>
	/// Restart execution
	/// </summary>
	Restart = 0x122,

	/// <summary>
	/// Save VM state
	/// </summary>
	Save = 0x123,

	/// <summary>
	/// Restore VM state
	/// </summary>
	Restore = 0x124,

	/// <summary>
	/// Save VM location in a temporary location
	/// </summary>
	SaveUndo = 0x125,
	
	/// <summary>
	/// Restore VM from temporary location
	/// </summary>
	RestoreUndo = 0x126,

	/// <summary>
	/// Protect memory from restart, restore, restoreundo
	/// </summary>
	Protect = 0x127,

	/// <summary>
	/// Tests if undo state exists in temporary storage
	/// </summary>
	HasUndo = 0x128,

	/// <summary>
	/// Discard VM state from temporary storage
	/// </summary>
	DiscardUndo = 0x129,

	/* G L K  A P I */

	/// <summary>
	/// Call Glk API function
	/// </summary>
	Glk = 0x130,

	/* S T R I N G  D E C O D I N G  T A B L E */

	/// <summary>
	/// Get address of string decoding table
	/// </summary>
	GetStringTbl = 0x140,

	/// <summary>
	/// Set address of string decoding table
	/// </summary>
	///
	/// <remarks>
	/// Setting to 0 means there is no table and therefore compressed strings are illegal
	/// </remarks>
	SetStringTbl = 0x141,

	/* I / O  S Y S T E M S */

	/// <summary>
	/// Get current I/O system
	/// </summary>
	///
	/// <remarks>
	/// S1 and S2 must be the same value (Glulxe-term bug-feature)
	/// </remarks>
	GetIOSys = 0x148,

	/// <summary>
	/// Sets current I/O system
	/// </summary>
	///
	/// <remarks>
	/// 0 = null;
	/// 1 = Filtering;
	/// 2 = Glk;
	/// 3 = FyreVM;
	/// </remarks>
	SetIOSys = 0x149,

	/* S E A R C H  A L G O R I T H M S */

	/// <summary>
	/// Linear search algorithm
	/// </summary>
	LinearSearch = 0x150,

	/// <summary>
	/// Binary search algorithm
	/// </summary>
	BinarySearch = 0x151,

	/// <summary>
	/// Linked list search algorithm
	/// </summary>
	LinkedSearch = 0x152,

	/* C A L L I N G  C O N T D . */

	/// <summary>
	/// Call function with 0 arguments
	/// </summary>
	CallF = 0x160,

	/// <summary>
	/// Call function w/ 1 argument
	/// </summary>
	CallFI = 0x161,

	/// <summary>
	/// Call function w/ 2 arguments
	/// </summary>
	CallFII = 0x162,

	/// <summary>
	/// Call function w/ 3 arguments
	/// </summary>
	CallFIII = 0x163,

	/* M E M O R Y  A L L O C A T I O N S */

	/// <summary>
	/// Writes zeroes starting at an address
	/// </summary>
	MZero = 0x170,

	/// <summary>
	/// Copy memory
	/// </summary>
	MCopy = 0x171,
	
	/// <summary>
	/// Allocate byte block
	/// </summary>
	///
	/// <remarks>
	/// If allocation fails, S1 is 0
	/// </remarks>
	MAlloc = 0x178,

	/// <summary>
	/// Frees memory block
	/// </summary>
	MFree = 0x179,

	/* A C C E L E R A T E D  F U N C T I O N S */

	AccelFunc = 0x180,
	AccelParam = 0x181,

	/* F L O A T / I N T  C O N V E R S I O N */

	/// <summary>
	/// Integer to float
	/// </summary>
	NumToF = 0x190,

	/// <summary>
	/// Float to ingeger (with truncation)
	/// </summary>
	FToNumZ = 0x191,

	/// <summary>
	/// Float to integer (round towards nearest integer)
	/// </summary>
	FToNumN = 0x192,

	/* F L O A T I N G  P O I N T  M A T H */

	/// <summary>
	/// Ceiling
	/// </summary>
	Ceil = 0x198,

	/// <summary>
	/// Floor
	/// </summary>
	Floor = 0x199,

	/// <summary>
	/// Floating point addition
	/// </summary>
	FAdd = 0x1a0,

	/// <summary>
	/// Floating point subtraction
	/// </summary>
	FSub = 0x1a1,

	/// <summary>
	/// Floating point multiplication
	/// </summary>
	FMul = 0x1a2,

	/// <summary>
	/// Floating point division
	/// </summary>
	FDiv = 0x1a3,

	/// <summary>
	/// Floating point modulus
	/// </summary>
	FMod = 0x1a4,

	/* P O W E R S */

	/// <summary>
	/// Square root
	/// </summary>
	Sqrt = 0x1a8,

	/// <summary>
	/// e^x
	/// </summary>
	Exp = 0x1a9,

	/// <summary>
	/// Log(x)
	/// </summary>
	Log = 0x1aa,

	/// <summary>
	/// x^y
	/// </summary>
	Pow = 0x1ab,

	/* M A T H  F U N C T I O N S */

	/// <summary>
	/// Sine
	/// </summary>
	Sin = 0x1b0,

	/// <summary>
	/// Cosing
	/// </summary>
	Cos = 0x1b1,

	/// <summary>
	/// Tangent
	/// </summary>
	Tan = 0x1b2,
	
	/// <summary>
	/// Arc sine
	/// </summary>
	ASin = 0x1b3,

	/// <summary>
	/// Arc cosine
	/// </summary>
	ACos = 0x1b4,

	/// <summary>
	/// Arc tangent
	/// </summary>
	ATan = 0x1b5,

	/// <summary>
	/// Atan2
	/// </summary>
	ATan2 = 0x1b6,

	/* F L O A T I N G  P O I N T  C O M P A R I S O N S */

	JFEq = 0x1c0,
	JFNe = 0x1c1,
	JFLt = 0x1c3,
	JFGt = 0x1c4,
	JFGe = 0x1c5,

	JIsNan = 0x1c8,
	JIsInf = 0x1c9,

	/* D O U B L E  P R E C I S I O N  V A L U E S */

	/// <summary>
	/// Integer to double
	/// </summary>
	NumToD = 0x200,

	/// <summary>
	/// Double to integer with truncation
	/// </summary>
	DToNumZ = 0x201,

	/// <summary>
	/// Double to integer to nearest integer
	/// </summary>
	DToNumN = 0x202,

	/// <summary>
	/// Float to double
	/// </summary>
	FToD = 0x203,

	/// <summary>
	/// Double to float
	/// </summary>
	DToF = 0x204,

	/* D O U B L E  P R E C I S I O N  M A T H */

	/// <summary>
	/// Double precision ceiling
	/// </summary>
	DCeil = 0x208,

	/// <summary>
	/// Double precision floor
	/// </summary>
	DFloor = 0x209,

	/// <summary>
	/// Double precision addition
	/// </summary>
	DAdd = 0x210,

	/// <summary>
	/// Double precision subtraction
	/// </summary>
	DSub = 0x211,

	/// <summary>
	/// Double precision multiplication
	/// </summary>
	DMul = 0x212,

	/// <summary>
	/// Double precision division
	/// </summary>
	DDiv = 0x213,

	/// <summary>
	/// Double precision modulo remainder
	/// </summary>
	DModR = 0x214,

	/// <summary>
	/// Double precision modulo quotient
	/// </summary>
	DModQ = 0x215,

	/* D O U B L E  P R E C I S I O N  P O W E R S */

	/// <summary>
	/// Double precision square root
	/// </summary>
	DSqrt = 0x218,

	/// <summary>
	/// Double precision e^x
	/// </summary>
	DExp = 0x219,

	/// <summary>
	/// Double precision log
	/// </summary>
	DLog = 0x21a,

	/// <summary>
	/// Double precision x^y
	/// </summary>
	DPow = 0x21b,

	/* D O U B L E  P R E C I S I O N  F U N C T I O N S */

	/// <summary>
	/// Double precision sine
	/// </summary>
	DSin = 0x220,

	/// <summary>
	/// Double precision cosine
	/// </summary>
	DCos = 0x221,

	/// <summary>
	/// Double precision tangent
	/// </summary>
	DTan = 0x222,

	/// <summary>
	/// Double precision arc sine
	/// </summary>
	DASin = 0x223,

	/// <summary>
	/// Double precision arc cosine
	/// </summary>
	DACos = 0x224,

	/// <summary>
	/// Double precision arc tangent
	/// </summary>
	DATan = 0x225,

	/// <summary>
	/// Double precision Atan2
	/// </summary>
	DAtan2 = 0x226,

	/* D O U B L E  P R E C I S I O N  C O M P A R I S O N */

	JDEq = 0x230,
	JDNe = 0x231,
	JDLt = 0x232,
	JDLe = 0x233,
	JDGt = 0x234,
	JDGe = 0x235,
	JDIsNan = 0x238,
	JDIsInf = 0x239,

}
