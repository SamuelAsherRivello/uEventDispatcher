using RMC.Core.UEvents.Bus;
using System.Collections.Generic;
using UnityEngine;

namespace RMC.Core.UEvents.Examples
{
	public class UEventBusDemo : MonoBehaviour
	{
		//  Fields ---------------------------------------
		[SerializeField]
		public List<UEventBusAssetEntry> _uEventBusAssetEntries = new List<UEventBusAssetEntry>();

      //  Unity Methods   -------------------------------
      protected void OnValidate()
      {
         foreach (var x in _uEventBusAssetEntries)
         {
				if (x == null || x.FromUEventAsset == null || x.ToUEventAsset == null)
            {
					continue;
            }


				//HACK
				//TODO: Remove one SPECIFIC listener, DO NOT remove ALL
				x.FromUEventAsset.RemoveAllListeners();

				//Keep as is
				x.FromUEventAsset.AddListener((IUEventData uEventData) =>
				{
					x.ToUEventAsset.Invoke(uEventData);
				});
			}
      }
	}
}