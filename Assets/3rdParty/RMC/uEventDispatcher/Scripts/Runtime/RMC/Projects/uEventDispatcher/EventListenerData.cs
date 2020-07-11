namespace RMC.Projects.UEventDispatcher
{
	public class EventListenerData
	{
		//  Properties -----------------------------------
		public object EventListener
		{
			get { return _eventListener; }
			set { _eventListener = value; }
		}

		public EventDelegate EventDelegate
		{
			get { return _eventDelegate; }
			set { _eventDelegate = value; }
		}

		public string EventName
		{
			get { return _eventName; }
			set { _eventName = value; }
		}

		public EventDispatcherAddMode EventListeningMode
		{
			get { return _eventListeningMode; }
			set { _eventListeningMode = value; }
		}

		//  Fields ---------------------------------------
		private object _eventListener;
		private EventDelegate _eventDelegate;
		private string _eventName;
		private EventDispatcherAddMode _eventListeningMode;

		//  Initialization -------------------------------
		public EventListenerData(object eventListener, string eventName, EventDelegate eventDelegate, 
			EventDispatcherAddMode eventDispatcherAddMode)
		{
			_eventListener = eventListener;
			_eventName = eventName;
			_eventDelegate = eventDelegate;
			_eventListeningMode = eventDispatcherAddMode;
		}
	}
}