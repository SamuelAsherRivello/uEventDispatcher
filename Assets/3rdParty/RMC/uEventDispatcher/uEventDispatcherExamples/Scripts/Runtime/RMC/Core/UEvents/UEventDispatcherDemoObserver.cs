using RMC.Core.UEvents.UEventDispatcher;
using UnityEngine;

namespace RMC.Core.UEvents
{
	public class UEventDispatcherDemoObserver : MonoBehaviour
	{
		protected void Start()
		{
			UEventData uEventData = new UEventData();
			EventDispatcherSingleton.Instance.AddEventListener<UEvent>(
				EventDispatcherSingleton_OnSampleEvent);
		}

		protected void OnDestroy()
		{
			if (EventDispatcherSingleton.IsInstantiated)
         {
				EventDispatcherSingleton.Instance.RemoveListener<UEvent>(
				EventDispatcherSingleton_OnSampleEvent);
			}
		}

      private void EventDispatcherSingleton_OnSampleEvent(IUEventData uEventData)
		{
			Debug.Log($"{this.GetType().Name} OnSampleEvent()...\n uEventData='{uEventData}'. Null is ok.\n\n");
		}
	}
}