using RMC.Core.Singleton;
using UnityEngine.Events;

namespace RMC.Core.UEvents.EventDispatcher
{
	public class EventDispatcherSingleton : SingletonMonobehavior<EventDispatcherSingleton>, 
      IUEventDispatcher
	{
		//  Fields ---------------------------------------
		private UEventDispatcher _eventDispatcher;

		//  Unity Methods   -------------------------------
		protected void Awake()
		{
			_eventDispatcher = new UEventDispatcher();
		}

      //  Methods   -------------------------------
      public void Invoke<T>(UEventData uEventData) where T : UEvent
      {
         _eventDispatcher.Invoke<T>(uEventData);
      }

      public void AddEventListener<T>(UnityAction<UEventData> unityAction) where T : UEvent
      {
         _eventDispatcher.AddEventListener<T>(unityAction);
      }

      public void RemoveAllListeners()
      {
         _eventDispatcher.RemoveAllListeners();
      }

      public void RemoveListener<T>(UnityAction<UEventData> unityAction) where T : UEvent
      {
         _eventDispatcher.RemoveListener<T>(unityAction);
      }
   }
}