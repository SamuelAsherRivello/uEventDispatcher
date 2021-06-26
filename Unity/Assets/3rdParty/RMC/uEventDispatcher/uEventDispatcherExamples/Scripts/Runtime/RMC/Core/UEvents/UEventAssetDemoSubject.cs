using RMC.Core.UEvents.Assets;
using UnityEngine;

namespace RMC.Core.UEvents.Examples
{
	public class MyCustomUEventData : IUEventData { }

	public class UEventAssetDemoSubject : MonoBehaviour
	{
		//  Fields ---------------------------------------
		[SerializeField]
		private UEventAsset _uEventAsset = null;

		//  Unity Methods   -------------------------------
		protected void Start ()
		{

			// Send with or without data

			_uEventAsset.InvokeNull();

			_uEventAsset.Invoke(new UEventData());

			_uEventAsset.Invoke(new MyCustomUEventData());
		}
	}
}