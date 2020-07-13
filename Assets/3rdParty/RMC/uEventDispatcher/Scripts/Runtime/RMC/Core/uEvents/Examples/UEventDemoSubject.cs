using UnityEngine;
using UnityEngine.Events;

namespace RMC.Core.UEvents.Examples
{
	public class UEventDemoSubject : MonoBehaviour
	{
		//  Fields ---------------------------------------
		[SerializeField]
		private UEvent _onAwake = new UEvent();

		//  Unity Methods   -------------------------------
		protected void Awake ()
		{
			_onAwake.Invoke(null);
		}
	}
}