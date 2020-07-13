using RMC.Core.UEvents.Assets;
using System;
using UnityEngine;

namespace RMC.Core.UEvents.Examples
{
	public class UEventDispatcherAssetDemo : MonoBehaviour
	{
		//  Fields ---------------------------------------
		[SerializeField]
		public UEventDispatcherAsset _uEventDispatcherAsset;

		//  Unity Methods   -------------------------------
		protected void Start ()
		{
			_uEventDispatcherAsset.DispatchEvent(new SampleEvent(SampleEvent.SAMPLE_EVENT, "some custom value"));
		}
	}
}