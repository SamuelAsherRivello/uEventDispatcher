namespace RMC.Core.UEvents.Examples
{
	public class SampleEvent : Event
	{
		//  Properties -----------------------------------
		public string CustomValue
		{
			get { return _customValue; }
			set { _customValue = value; }
		}

		//  Fields ---------------------------------------
		private string _customValue;
		public static string SAMPLE_EVENT = "SAMPLE_EVENT";

		//  Initialization -------------------------------
		public SampleEvent(string type, string customValue) : base(type)
		{
			_customValue = customValue;
		}
	}
}