using UnityEngine;

namespace RMC.Projects.UEventDispatcher.Examples
{
	//  Namespace Properties ------------------------------

	//  Class Attributes ----------------------------------
	public class SampleObservedComponent : MonoBehaviour
	{
		//  Fields ---------------------------------------
		public EventDispatcher EventDispatcher;

		//  Initialization -------------------------------
		public SampleObservedComponent()
		{
			EventDispatcher = new EventDispatcher(this);
		}

		//  Unity Methods   -------------------------------
		protected void Start()
		{
			SampleEvent sampleEvent = new SampleEvent(SampleEvent.SAMPLE_EVENT);
			sampleEvent.CustomValue = "foo";
			Debug.Log("Dispatching: SampleEvent " + sampleEvent);
			EventDispatcher.DispatchEvent(sampleEvent);
		}

		protected void OnDestroy()
		{
			EventDispatcher.RemoveAllEventListeners();
			EventDispatcher = null;
		}
	}
}