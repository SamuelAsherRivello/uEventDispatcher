using UnityEngine;

namespace RMC.Core.UEvents.Examples
{
	//  Namespace Properties ------------------------------

	//  Class Attributes ----------------------------------
	public class SampleObservedComponent : MonoBehaviour
	{
		//  Properties -------------------------------------
		public EventDispatcher.UEventDispatcher EventDispatcher { get { return _eventDispatcher; } }

		//  Fields ---------------------------------------
		private EventDispatcher.UEventDispatcher _eventDispatcher;

		//  Unity Methods   -------------------------------
		protected void Awake ()
		{
			_eventDispatcher = new EventDispatcher.UEventDispatcher();
		}

		protected void Start()
		{
			UEventData uEventData = new UEventData();
			_eventDispatcher.Invoke<UEvent>(uEventData);
		}

		protected void OnDestroy()
		{
			if (_eventDispatcher != null)
         {
				_eventDispatcher.RemoveAllListeners();
				_eventDispatcher = null;
			}
		}
	}
}