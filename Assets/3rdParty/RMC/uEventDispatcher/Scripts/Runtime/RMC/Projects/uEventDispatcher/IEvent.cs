namespace RMC.Projects.UEventDispatcher
{
	public interface IEvent
	{
		//  Properties -----------------------------------
		string Type { get; set; }
		object Target { get; set; }
	}
}
