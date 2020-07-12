using System;
using UnityEngine;

namespace RMC.Core.UEvents.Examples
{
	public class EventDispatcherAssetDemo : MonoBehaviour
	{
		//  Fields ---------------------------------------
		[SerializeField]
		public EventDispatcherAsset eventDispatcherAsset;

		//  Unity Methods   -------------------------------
		protected void Start ()
		{
			eventDispatcherAsset.DispatchEvent(new SampleEvent(SampleEvent.SAMPLE_EVENT, "some custom value"));
		}
	}
}