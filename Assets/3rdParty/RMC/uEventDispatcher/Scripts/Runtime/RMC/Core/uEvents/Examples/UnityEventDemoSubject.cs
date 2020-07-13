using UnityEngine;
using UnityEngine.Events;

namespace RMC.Core.UEvents.Examples
{
	public class UnityEventDemoSubject : MonoBehaviour
	{
		//  Fields ---------------------------------------
		[SerializeField]
		private UnityEvent _onAwake = new UnityEvent();

		//  Unity Methods   -------------------------------
		protected void Awake ()
		{
			_onAwake.Invoke();
		}
	}
}