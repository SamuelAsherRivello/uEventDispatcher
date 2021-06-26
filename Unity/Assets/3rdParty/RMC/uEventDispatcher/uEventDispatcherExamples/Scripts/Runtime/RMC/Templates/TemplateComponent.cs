using UnityEngine;

namespace RMC.Templates
{
	public class TemplateComponent : MonoBehaviour
	{
		//  Properties ------------------------------------------
		public string SamplePublicText { get { return _samplePublicText; } set { _samplePublicText = value; } }

		//  Fields ----------------------------------------------
		[SerializeField]
		private string _samplePublicText;

		//  Initialization --------------------------------------

		//  Unity Methods ---------------------------------------
		protected void Start()
		{

		}

		protected void Update()
		{

		}

		//  Methods ---------------------------------------------
		public string SamplePublicMethod(string message)
		{
			return message;
		}

		//  Event Handlers --------------------------------------
		public void Target_OnEventOccurred(string message)
		{

		}
	}
}