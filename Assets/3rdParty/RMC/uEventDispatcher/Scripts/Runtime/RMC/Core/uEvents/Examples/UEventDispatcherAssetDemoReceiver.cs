﻿using RMC.Core.UEvents.Assets;
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
			UEventData uEventData = new UEventData();
			_uEventDispatcherAsset.AddEventListener<UEvent>(EventAsset_OnSampleEvent);
		}

      protected void OnDisable()
		{
			_uEventDispatcherAsset.RemoveListener<UEvent>(EventAsset_OnSampleEvent);
		}

		//  Event Handlers   -------------------------------
		private void EventAsset_OnSampleEvent(UEventData uEventData)
		{
			Debug.Log($"{this.GetType().Name} OnSampleEvent() uEventData={uEventData}");
		}
	}
}