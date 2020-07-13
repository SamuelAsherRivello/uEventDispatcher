using RMC.Core.UEvents.Assets;
using UnityEngine;

namespace RMC.Core.UEvents.Examples
{
	public class UEventDispatcherAssetDemoReceiver : MonoBehaviour
	{
		//  Fields ---------------------------------------
		[SerializeField]
		public UEventDispatcherAsset _uEventDispatcherAsset = null;

		//  Unity Methods   -------------------------------
		protected void OnEnable()
		{
			_uEventDispatcherAsset.AddEventListener(SampleEvent.SAMPLE_EVENT, EventAsset_OnSampleEvent);
		}

		protected void OnDisable()
		{
			_uEventDispatcherAsset.RemoveEventListener(SampleEvent.SAMPLE_EVENT, EventAsset_OnSampleEvent);
		}

		//  Event Handlers   -------------------------------
		private void EventAsset_OnSampleEvent(IEvent iEvent)
		{
			SampleEvent sampleEvent = (SampleEvent)iEvent;

			Debug.Log($"{this.GetType().Name} OnSampleEvent() CustomValue={sampleEvent.CustomValue}");
		}
	}
}