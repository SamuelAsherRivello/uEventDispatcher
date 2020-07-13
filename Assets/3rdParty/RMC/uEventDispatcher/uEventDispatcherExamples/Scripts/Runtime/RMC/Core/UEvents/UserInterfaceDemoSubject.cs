using RMC.Core.UEvents.Assets;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace RMC.Core.UEvents.Examples
{
	public class UserInterfaceDemoSubject : MonoBehaviour
	{
		//  Fields ---------------------------------------
		[SerializeField]
		private UEventAsset _onLeftClicked = null;

		[SerializeField]
		private UEventAsset _onRightClicked = null;

		[SerializeField]
		private Button _leftButton = null;

		[SerializeField]
		private Button _rightButton = null;

		//  Unity Methods   -------------------------------
		protected void Awake()
		{
			_leftButton.onClick.AddListener(()=>
			{
				_onLeftClicked.InvokeNull();
			});

			_rightButton.onClick.AddListener(() =>
			{
				_onRightClicked.InvokeNull();
			});
		}

		//  Event Handlers   -------------------------------
		private void OnEvent(IUEventData uEventData)
		{
			Debug.Log($"{this.GetType().Name} OnEvent() uEventData='{uEventData}'. Null is ok.");
		}
	}
}