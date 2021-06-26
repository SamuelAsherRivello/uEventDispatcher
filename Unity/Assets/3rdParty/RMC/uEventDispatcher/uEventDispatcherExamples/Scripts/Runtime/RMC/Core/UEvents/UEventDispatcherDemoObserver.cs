using RMC.Core.UEvents.UEventDispatcher;
using UnityEngine;

namespace RMC.Core.UEvents.Examples
{
	public class UEventDispatcherDemoObserver : MonoBehaviour
	{
		protected void Start()
		{
			UEventData uEventData = new UEventData();
			UEventDispatcherSingleton.Instance.AddEventListener<UEvent>(
				EventDispatcherSingleton_OnSampleEvent);
		}

		protected void OnDestroy()
		{
			if (UEventDispatcherSingleton.IsInstantiated)
         {
				UEventDispatcherSingleton.Instance.RemoveListener<UEvent>(
				EventDispatcherSingleton_OnSampleEvent);
			}
		}

      private void EventDispatcherSingleton_OnSampleEvent(IUEventData uEventData)
		{
			Debug.Log($"{this.GetType().Name} OnSampleEvent()...\n uEventData='{uEventData}'. Null is ok.\n\n");
		}
	}
}