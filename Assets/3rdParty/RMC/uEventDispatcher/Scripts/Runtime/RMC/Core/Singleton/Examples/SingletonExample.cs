using UnityEngine;

namespace RMC.Core.Singleton.Examples
{
	public class SingletonExample
	{
		public static SingletonExample Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new SingletonExample();
				}
				return _instance;
			}
		}

		private static SingletonExample _instance;

		private SingletonExample ()
		{
			Debug.Log($"{this.GetType().Name} Constructor");
			_instance = this;
		}

		public void SayHelloWorld()
		{
			Debug.Log($"{this.GetType().Name} Hello World!");
		}
	}
}