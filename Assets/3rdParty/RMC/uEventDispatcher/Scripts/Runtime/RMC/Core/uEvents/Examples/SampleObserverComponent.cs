using System;
using UnityEngine;

namespace RMC.Core.UEvents.Examples
{
	public class SampleObserverComponent : MonoBehaviour
	{
		//  Fields ---------------------------------------
		[SerializeField]
		private SampleObservedComponent SampleObservedGameObject = null;

		//  Unity Methods   ------------------------------
		protected void Start()
		{
			UEventData uEventData = new UEventData();
			SampleObservedGameObject.EventDispatcher.AddEventListener<UEvent>(
				SampleObservedComponent_OnSampleEvent);
		}

		//TODO: Show cleanup in every demo
      protected void OnDestroy()
		{
			SampleObservedGameObject?.EventDispatcher?.RemoveListener<UEvent>(
				SampleObservedComponent_OnSampleEvent);
		}

		//  Event Handlers    ------------------------------
		private void SampleObservedComponent_OnSampleEvent(UEventData uEventData)
		{
			Debug.Log($"{this.GetType().Name} OnSampleEvent() uEventData={uEventData}");
		}
	}
}