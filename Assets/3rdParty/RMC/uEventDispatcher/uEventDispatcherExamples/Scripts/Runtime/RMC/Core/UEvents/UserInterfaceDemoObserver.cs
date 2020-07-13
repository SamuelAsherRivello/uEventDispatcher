using RMC.Core.UEvents.Assets;
using UnityEngine;

namespace RMC.Core.UEvents.Examples
{
	public class UserInterfaceDemoObserver : MonoBehaviour
	{
		//  Fields ---------------------------------------
		[SerializeField]
		private UEventAsset _onLeftClicked = null;

		[SerializeField]
		private UEventAsset _onRightClicked = null;

		//  Unity Methods   -------------------------------
		protected void OnEnable()
		{
			_onLeftClicked.AddListener(OnLeftClicked);
			_onRightClicked.AddListener(OnRightClicked);
		}

		protected void OnDisable()
		{
			_onLeftClicked.RemoveListener(OnLeftClicked);
			_onRightClicked.RemoveListener(OnRightClicked);
		}

		//  Event Handlers   -------------------------------
		private void OnLeftClicked(IUEventData uEventData)
		{
			Debug.Log($"{this.GetType().Name} OnLeftClicked() uEventData='{uEventData}'. Null is ok.");
		}

		private void OnRightClicked(IUEventData uEventData)
		{
			Debug.Log($"{this.GetType().Name} OnRightClicked() uEventData='{uEventData}'. Null is ok.");
		}
	}
}