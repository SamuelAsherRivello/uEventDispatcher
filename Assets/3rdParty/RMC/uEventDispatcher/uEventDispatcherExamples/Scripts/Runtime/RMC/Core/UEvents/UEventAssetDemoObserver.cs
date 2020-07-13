using RMC.Core.UEvents.Assets;
using UnityEngine;

namespace RMC.Core.UEvents.Examples
{
	public class UEventAssetDemoObserver : MonoBehaviour
	{
		//  Fields ---------------------------------------
		[SerializeField]
		private UEventAsset _uEventAsset = null;

		//  Unity Methods   -------------------------------
		protected void OnEnable()
		{
			_uEventAsset.AddListener(OnEvent);
		}

		protected void OnDisable()
		{
			_uEventAsset.RemoveListener(OnEvent);
		}

		//  Event Handlers   -------------------------------
		private void OnEvent(IUEventData uEventData)
		{
			Debug.Log($"{this.GetType().Name} OnEvent() uEventData='{uEventData}'. Null is ok.");
		}
	}
}