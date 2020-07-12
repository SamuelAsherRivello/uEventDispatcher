using UnityEngine;

namespace RMC.Core.UEvents.Examples
{
	public class EventDispatcherAssetDemoReceiver : MonoBehaviour
	{
		//  Fields ---------------------------------------
		[SerializeField]
		public EventDispatcherAsset eventDispatcherAsset;

		//  Unity Methods   -------------------------------
		protected void OnEnable()
		{
			eventDispatcherAsset.AddEventListener(SampleEvent.SAMPLE_EVENT, EventAsset_OnSampleEvent);
		}

		protected void OnDisable()
		{
			eventDispatcherAsset.RemoveEventListener(SampleEvent.SAMPLE_EVENT, EventAsset_OnSampleEvent);
		}

		//  Event Handlers   -------------------------------
		private void EventAsset_OnSampleEvent(IEvent iEvent)
		{
			SampleEvent sampleEvent = (SampleEvent)iEvent;

			Debug.Log($"{this.GetType().Name} OnSampleEvent() CustomValue={sampleEvent.CustomValue}");
		}
	}
}