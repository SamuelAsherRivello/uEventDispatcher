using UnityEngine;

namespace RMC.Projects.UEventDispatcher.Examples
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
		private void SampleObservedComponent_onSampleEvent(IEvent aIEvent)
		{

			Debug.Log("\tListening: _onSampleEvent() aIEvent: " + aIEvent + " with customValue: " + (aIEvent as SampleEvent).CustomValue);

		}
	}
}