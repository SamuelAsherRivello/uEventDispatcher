using UnityEngine;

namespace RMC.Core.UEvents.Examples
{
	public class SampleObserverComponent : MonoBehaviour
	{
		//  Fields ---------------------------------------
		public SampleObservedComponent SampleObservedGameObject;

		//  Unity Methods   ------------------------------
		protected void Start()
		{
			SampleObservedGameObject.EventDispatcher.AddEventListener(SampleEvent.SAMPLE_EVENT,
				SampleObservedComponent_onSampleEvent);

		}
		protected void OnDestroy()
		{
			SampleObservedGameObject?.EventDispatcher?.RemoveEventListener(SampleEvent.SAMPLE_EVENT,
				SampleObservedComponent_onSampleEvent);
		}

		//  Event Handlers    ------------------------------
		private void SampleObservedComponent_onSampleEvent(IEvent iEvent)
		{
			SampleEvent sampleEvent = (SampleEvent)iEvent;

			Debug.Log($"{this.GetType().Name} OnSampleEvent() CustomValue={sampleEvent.CustomValue}");
		}
	}
}