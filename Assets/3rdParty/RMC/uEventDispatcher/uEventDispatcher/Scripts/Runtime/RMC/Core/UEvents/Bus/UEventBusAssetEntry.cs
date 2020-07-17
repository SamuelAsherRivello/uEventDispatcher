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

		//  Fields ---------------------------------------
		[SerializeField]
		private UEventAsset _fromUEventAsset = null;

		[SerializeField]
		private float _test = 22;

		[SerializeField]
		private UEventAsset _toUEventAsset = null;
	}
}