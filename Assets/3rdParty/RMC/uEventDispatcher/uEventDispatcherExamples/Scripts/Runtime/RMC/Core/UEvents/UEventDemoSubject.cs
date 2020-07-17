using UnityEngine;

namespace RMC.Core.UEvents.Examples
{
	public class UEventDemoSubject : MonoBehaviour
	{
		//  Fields ---------------------------------------
		[SerializeField]
		private UEvent _onAwaked = new UEvent();

		//  Unity Methods   -------------------------------
		protected void Awake ()
		{
			_onAwaked.Invoke(null);
		}
	}
}