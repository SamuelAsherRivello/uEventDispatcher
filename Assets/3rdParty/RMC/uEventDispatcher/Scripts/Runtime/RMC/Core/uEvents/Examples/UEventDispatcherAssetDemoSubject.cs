using RMC.Core.UEvents.UEventDispatcher.Assets;
using UnityEngine;

namespace RMC.Core.UEvents.Examples
{
	public class UEventDispatcherAssetDemoSubject : MonoBehaviour
	{
		//  Fields ---------------------------------------
		[SerializeField]
		public UEventDispatcherAsset _uEventDispatcherAsset;

		//  Unity Methods   -------------------------------
		protected void Start ()
		{
			_uEventDispatcherAsset.Invoke<UEvent>(null);
		}
	}
}