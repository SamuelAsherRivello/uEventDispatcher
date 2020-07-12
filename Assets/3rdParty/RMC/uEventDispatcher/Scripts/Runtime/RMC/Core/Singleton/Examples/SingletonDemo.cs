using UnityEngine;

namespace RMC.Core.Singleton.Examples
{
	/// <summary>
	/// Ensure a class has only one instance and provide a global point of access to it.
	/// See <a href="https://www.dofactory.com/net/singleton-design-pattern">docs</a>.
	/// </summary>
	public class SingletonDemo : MonoBehaviour
	{
		protected void Start()
		{
			SingletonExample.Instance.SayHelloWorld();
			SingletonExample.Instance.SayHelloWorld();
		}
	}
}