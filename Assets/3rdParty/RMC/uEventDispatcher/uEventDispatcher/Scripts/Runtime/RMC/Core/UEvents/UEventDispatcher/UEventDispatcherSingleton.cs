using RMC.Core.Singleton;
using UnityEngine.Events;

namespace RMC.Core.UEvents.UEventDispatcher
{
	public class UEventDispatcherSingleton : SingletonMonobehavior<UEventDispatcherSingleton>, 
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
      public void Invoke<T>(IUEventData uEventData) where T : IUEvent
      {
         _eventDispatcher.Invoke<T>(uEventData);
      }

      public void AddEventListener<T>(UnityAction<IUEventData> unityAction) where T : IUEvent
      {
         _eventDispatcher.AddEventListener<T>(unityAction);
      }

      public void RemoveAllListeners()
      {
         _eventDispatcher.RemoveAllListeners();
      }

      public void RemoveListener<T>(UnityAction<IUEventData> unityAction) where T : IUEvent
      {
         _eventDispatcher.RemoveListener<T>(unityAction);
      }
   }
}