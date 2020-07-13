using RMC.Core.Singleton;

namespace RMC.Core.UEvents.EventDispatcher
{
	public class EventDispatcherSingleton : SingletonMonobehavior<EventDispatcherSingleton>
	{
		//  Fields ---------------------------------------
		private UEventDispatcher _eventDispatcher;

		//  Unity Methods   -------------------------------
		protected void Awake()
		{
			_eventDispatcher = new UEventDispatcher(this);
		}

      //  Methods   -------------------------------
      public bool AddEventListener(string type, EventDelegate eventDelegate)
      {
         return _eventDispatcher.AddEventListener(type, eventDelegate);
      }

      public bool AddEventListener(string type, EventDelegate eventDelegate, EventDispatcherAddMode eventDispatcherAddMode)
      {
         return _eventDispatcher.AddEventListener(type, eventDelegate, eventDispatcherAddMode);
      }

      public bool DispatchEvent(IEvent iEvent)
      {
         return _eventDispatcher.DispatchEvent(iEvent);
      }

      public bool HasEventListener(string type, EventDelegate eventDelegate)
      {
         return _eventDispatcher.HasEventListener(type, eventDelegate);
      }

      public bool RemoveAllEventListeners()
      {
         return _eventDispatcher.RemoveAllEventListeners();
      }

      public bool RemoveEventListener(string type, EventDelegate eventDelegate)
      {
         return _eventDispatcher.RemoveEventListener(type, eventDelegate);
      }
   }
}