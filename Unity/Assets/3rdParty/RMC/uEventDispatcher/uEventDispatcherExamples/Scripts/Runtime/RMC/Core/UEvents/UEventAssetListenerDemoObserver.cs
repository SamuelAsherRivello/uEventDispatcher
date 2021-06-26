using UnityEngine;

namespace RMC.Core.UEvents.Examples
{
	public class UEventAssetListenerDemoObserver : MonoBehaviour
	{
		//  Methods   -------------------------------
		public void SayHelloWorld(IUEventData uEventData)
		{
			Debug.Log($"{this.GetType().Name} Hello World! uEventData='{uEventData}'. Null is ok.");
		}
	}
}