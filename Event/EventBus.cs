namespace IFDotNet;

/// <summary>
/// Event bus
/// </summary>
public class EventBus
{
	private Dictionary<Type, List<Delegate>> data = new();

	/// <summary>
	/// Subscribe to an event
	/// </summary>
	///
	/// <type name="TEvent">
	/// Event type to subscribe to
	/// </type>
	///
	/// <param name="handler">
	/// Event handler
	/// </param>
	public void Subscribe<TEvent>(Action<TEvent> handler) where TEvent : IEvent
	{
		if (!data.ContainsKey(typeof(TEvent)))
		{
			data[typeof(TEvent)]  = new List<Delegate>();
		}

		data[typeof(TEvent)].Add(handler);
	}

	/// <summary>
	/// Unsubscribe from an event
	/// </summary>
	///
	/// <type name="TEvent">
	/// Event type to subscribe to
	/// </type>
	///
	/// <param name="handler">
	/// Event handler
	/// </param>
	public void Unsubscribe<TEvent>(Action<TEvent> handler) where TEvent : IEvent
	{
		data[typeof(TEvent)].Remove(handler);
	}

	/// <summary>
	/// Publish an event and trigger its handler(s)
	/// </summary>
	///
	/// <type name="TEvent">
	/// Event type
	/// </type>
	///
	/// <param name="eventData">
	/// Data to send to event handler
	/// </param>
	public void Publish<TEvent>(TEvent eventData) where TEvent : IEvent
	{
		if (data.ContainsKey(typeof(TEvent)))
		{
			foreach (var handler in data[typeof(TEvent)].Cast<Action<TEvent>>())
			{
				handler(eventData);
			}
		}
	}
}
