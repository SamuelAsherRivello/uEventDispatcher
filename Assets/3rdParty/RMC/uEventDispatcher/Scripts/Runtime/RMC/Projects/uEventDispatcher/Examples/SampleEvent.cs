namespace RMC.Projects.UEventDispatcher.Examples
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
		public SampleEvent(string type) : base(type)
		{

		}
	}
}