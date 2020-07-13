namespace RMC.Core.UEvents.EventDispatcher
{
	public interface IEventDispatcher
	{
		//  Methods --------------------------------
		bool AddEventListener(string type, EventDelegate eventDelegate);
		bool AddEventListener(string type, EventDelegate eventDelegate, EventDispatcherAddMode eventDispatcherAddMode);
		bool HasEventListener(string type, EventDelegate eventDelegate);
		bool RemoveEventListener(string type, EventDelegate eventDelegate);
		bool RemoveAllEventListeners();
		bool DispatchEvent(IEvent iEvent);
	}
}
