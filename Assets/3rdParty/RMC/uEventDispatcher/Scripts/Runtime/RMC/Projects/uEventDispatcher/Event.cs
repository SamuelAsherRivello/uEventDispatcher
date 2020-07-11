namespace RMC.Projects.UEventDispatcher
{
	public class Event : IEvent
	{
		//  Properties -----------------------------------
		string IEvent.Type
		{
			get { return _type_string; }
			set { _type_string = value; }
		}

		object IEvent.Target
		{
			get { return _target; }
			set { _target = value; }
		}

      //  Fields ---------------------------------------
      private string _type_string;
		private object _target;

		//  Initialization -------------------------------
		public Event(string aType_str)
		{
			//
			_type_string = aType_str;

		}
	}
}
