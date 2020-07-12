using UnityEngine;

namespace RMC.Core.Singleton.Examples
{
	public class SingletonMonoBehaviourDemo : MonoBehaviour
	{
		protected void Start()
		{
			SingletonMonoBehaviourExample.Instance.SayHelloWorld();
		}
	}
}