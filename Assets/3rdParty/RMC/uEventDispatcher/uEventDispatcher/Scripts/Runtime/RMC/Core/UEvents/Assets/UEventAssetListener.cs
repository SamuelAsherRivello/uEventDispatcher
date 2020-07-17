using UnityEngine;

namespace RMC.Core.UEvents.Assets
{
	public class UEventAssetListener : MonoBehaviour
	{
		//  Fields ---------------------------------------
		[SerializeField]
		private UEventAsset _uEventAsset = null;

		[SerializeField]
		private UEvent _uEvent = new UEvent();

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
			_uEvent.Invoke(uEventData);
		}
	}
}