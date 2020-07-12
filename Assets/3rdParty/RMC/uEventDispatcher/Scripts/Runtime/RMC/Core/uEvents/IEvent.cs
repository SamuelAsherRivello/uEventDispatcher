namespace RMC.Core.UEvents
{
	public interface IEvent
	{
		//  Properties -----------------------------------
		string Type { get; set; }
		object Target { get; set; }
	}
}
