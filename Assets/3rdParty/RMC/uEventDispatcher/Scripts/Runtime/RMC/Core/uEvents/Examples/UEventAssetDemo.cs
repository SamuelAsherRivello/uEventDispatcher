using RMC.Core.UEvents.Assets;
using System;
using UnityEngine;

namespace RMC.Core.UEvents.Examples
{
	public class CustomData : UEventData {}

	public class UEventAssetDemo : MonoBehaviour
	{
		//  Fields ---------------------------------------
		[SerializeField]
		private UEventAsset _uEventAsset = null;

		//  Unity Methods   -------------------------------
		protected void Start ()
		{

			// Send with or without data

			_uEventAsset.Invoke();

			_uEventAsset.Invoke(new UEventData());

			_uEventAsset.Invoke(new CustomData());
		}
	}
}