namespace RMC.Core.UEvents
{
	public class Event : IEvent
	{
		//  Properties -----------------------------------
		string IEvent.Type
		{
			get { return _type; }
			set { _type = value; }
		}

		object IEvent.Target
		{
			get { return _target; }
			set { _target = value; }
		}

      //  Fields ---------------------------------------
      private string _type;
		private object _target;

		//  Initialization -------------------------------
		public Event(string type)
		{
			//
			_type = type;
		}
	}
}
