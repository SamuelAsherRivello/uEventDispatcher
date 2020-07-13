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
			_eventDispatcher = new EventDispatcher.UEventDispatcher(this);
		}

		protected void Start()
		{
			SampleEvent sampleEvent = new SampleEvent(SampleEvent.SAMPLE_EVENT, "foo");
			Debug.Log("Dispatching: SampleEvent " + sampleEvent);
			_eventDispatcher.DispatchEvent(sampleEvent);
		}

		protected void OnDestroy()
		{
			_eventDispatcher.RemoveAllEventListeners();
			_eventDispatcher = null;
		}
	}
}