namespace IFDotNet;

/// <summary>
/// Move the player to a different room
/// </summary>
public class MovePlayerEvent : IEvent
{
	internal Room Target;
	internal bool Look;

	/// <param name="target">
	/// Target room
	/// </param>
	///
	/// <param name="look">
	/// Whether to run a <see cref="LookMove" /> after moving the room, set this to <c>false</c> to move the player silently.
	/// </param>
	public MovePlayerEvent(Room target, bool look = true)
	{
		Target = target;
		Look = look;
	}
}
