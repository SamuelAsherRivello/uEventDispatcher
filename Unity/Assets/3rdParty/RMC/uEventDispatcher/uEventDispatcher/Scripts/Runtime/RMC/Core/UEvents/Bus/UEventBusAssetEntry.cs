using RMC.Core.UEvents.Assets;
using System;
using UnityEngine;

namespace RMC.Core.UEvents.Bus
{
	[Serializable]
	public class UEventBusAssetEntry
	{
		//  Fields ---------------------------------------
		public UEventAsset FromUEventAsset { set { _fromUEventAsset = value; } get { return _fromUEventAsset; } }
		public UEventAsset ToUEventAsset { set { _toUEventAsset = value; } get { return _toUEventAsset; } }
		public float Delay { set { _delay = value; } get { return _delay; } }


		//  Fields ---------------------------------------
		[SerializeField]
		private UEventAsset _fromUEventAsset = null;

		[SerializeField]
		private UEventAsset _toUEventAsset = null;

		[SerializeField]
		private float _delay = 0;
	}
}