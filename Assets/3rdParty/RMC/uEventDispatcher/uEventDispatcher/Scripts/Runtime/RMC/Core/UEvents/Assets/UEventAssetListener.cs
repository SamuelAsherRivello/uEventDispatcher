using UnityEngine;

namespace RMC.Core.UEvents.Assets
{
	public class UEventAssetListener : MonoBehaviour
	{
		//  Properties ---------------------------------------
		public UEventAsset UEventAsset { set { _uEventAsset = value; } get { return _uEventAsset; } }
		public UEvent UEvent { set { _uEvent = value; } get { return _uEvent; } }

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