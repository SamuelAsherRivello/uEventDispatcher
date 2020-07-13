using UnityEngine;

namespace RMC.Core.UEvents.Examples
{
	public class UnityEventDemoObserver : MonoBehaviour
	{
		//  Methods   -------------------------------
		public void SayHelloWorld()
		{
			Debug.Log($"{this.GetType().Name} Hello World!");
		}
	}
}