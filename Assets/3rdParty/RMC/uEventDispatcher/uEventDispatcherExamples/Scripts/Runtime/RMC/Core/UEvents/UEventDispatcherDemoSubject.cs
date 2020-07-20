using RMC.Core.UEvents.UEventDispatcher;
using RMC.Core.UEvents.Examples;
using System.Collections;
using UnityEngine;

namespace RMC.Core.UEvents.Examples
{
	public class UEventDispatcherDemoSubject : MonoBehaviour
	{
		protected void Start()
		{
			StartCoroutine(WaitAndDispatchEvent());
		}

      private IEnumerator WaitAndDispatchEvent()
      {
			yield return new WaitForSeconds(1);

			UEventData uEventData = new UEventData();
			UEventDispatcherSingleton.Instance.Invoke<UEvent>(uEventData);
		}
	}
}