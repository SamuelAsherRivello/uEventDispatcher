using RMC.Core.UEvents.EventDispatcher;
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
			EventDispatcherSingleton.Instance.RemoveListener<UEvent>(
				EventDispatcherSingleton_OnSampleEvent);
		}

      private void EventDispatcherSingleton_OnSampleEvent(UEventData uEventData)
		{
			Debug.Log($"{this.GetType().Name} OnSampleEvent() uEventData={uEventData}");
		}
	}
}