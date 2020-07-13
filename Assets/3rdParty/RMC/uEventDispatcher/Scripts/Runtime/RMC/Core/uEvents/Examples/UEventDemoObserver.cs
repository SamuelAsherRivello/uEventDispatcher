using UnityEngine;

namespace RMC.Core.UEvents.Examples
{
	public class UEventDemoObserver : MonoBehaviour
	{
		//  Methods   -------------------------------
		public void SayHelloWorld()
		{
			Debug.Log($"{this.GetType().Name} Hello World!");
		}
	}
}