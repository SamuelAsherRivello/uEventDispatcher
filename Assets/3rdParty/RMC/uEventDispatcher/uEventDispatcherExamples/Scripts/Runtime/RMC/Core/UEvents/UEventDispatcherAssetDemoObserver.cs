using RMC.Core.UEvents.UEventDispatcher.Assets;
using UnityEngine;

namespace RMC.Core.UEvents.Examples
{
	public class UEventDispatcherAssetDemoObserver : MonoBehaviour
	{
		//  Fields ---------------------------------------
		[SerializeField]
		public UEventDispatcherAsset _uEventDispatcherAsset = null;

		//  Unity Methods   -------------------------------
		protected void OnEnable()
		{
			UEventData uEventData = new UEventData();
			_uEventDispatcherAsset.AddEventListener<UEvent>(EventAsset_OnSampleEvent);
		}

      protected void OnDisable()
		{
			_uEventDispatcherAsset.RemoveListener<UEvent>(EventAsset_OnSampleEvent);
		}

		//  Event Handlers   -------------------------------
		private void EventAsset_OnSampleEvent(IUEventData uEventData)
		{
			Debug.Log($"{this.GetType().Name} OnSampleEvent() uEventData='{uEventData}'. Null is ok.");
		}
	}
}