using RMC.Core.UEvents.EventDispatcher;
using RMC.Core.UEvents.Examples;
using System;
using System.Collections;
using UnityEngine;

namespace RMC.Core.UEvents
{
	public class EventDispatcherSingletonDemo : MonoBehaviour
	{
		protected void Start()
		{
			EventDispatcherSingleton.Instance.AddEventListener (SampleEvent.SAMPLE_EVENT,
				EventDispatcherSingleton_OnSampleEvent);

			StartCoroutine(WaitAndCall());
		}

      private IEnumerator WaitAndCall()
      {
			yield return new WaitForSeconds(1);

			SampleEvent sampleEvent = new SampleEvent(SampleEvent.SAMPLE_EVENT, "some custom value");

			EventDispatcherSingleton.Instance.DispatchEvent(sampleEvent);
		}

		private void EventDispatcherSingleton_OnSampleEvent(IEvent iEvent)
		{
			SampleEvent sampleEvent = (SampleEvent)iEvent;

			Debug.Log($"{this.GetType().Name} OnSampleEvent() CustomValue={sampleEvent.CustomValue}");
		}
	}
}