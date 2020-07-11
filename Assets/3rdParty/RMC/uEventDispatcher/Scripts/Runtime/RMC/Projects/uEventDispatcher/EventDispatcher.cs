using UnityEngine;
using System.Collections;

namespace RMC.Projects.UEventDispatcher
{
	//  Namespace Properties ------------------------------
	public delegate void EventDelegate(IEvent iEvent);

	public enum EventDispatcherAddMode
	{
		DEFAULT,
		SINGLE_SHOT
	}

	//  Class Attributes ----------------------------------
	public class EventDispatcher : IEventDispatcher
	{
		//  Fields ---------------------------------------
		private Hashtable eventListenerData = new Hashtable();
		private object _target;

		//  Initialization -------------------------------
		public EventDispatcher(object target)
		{
			_target = target;
		}

		//  Unity Methods --------------------------------
		public void OnApplicationQuit()
		{
			//TODO, DO THIS CLEANUP HERE, OR OBLIGATE API-USER TO DO IT??
			eventListenerData.Clear();
		}

		//  Methods --------------------------------
		public bool AddEventListener(string eventName, EventDelegate eventDelegate)
		{
			return AddEventListener(eventName, eventDelegate, EventDispatcherAddMode.DEFAULT);
		}
		public bool AddEventListener(string eventName, EventDelegate eventDelegate, EventDispatcherAddMode eventDispatcherAddMode)
		{
			//
			bool wasSuccessful_boolean = false;

			//
			object aIEventListener = _getArgumentsCallee(eventDelegate);

			//
			if (aIEventListener != null && eventName != null)
			{

				//	OUTER
				string keyForOuterHashTable_string = _getKeyForOuterHashTable(eventName);
				if (!this.eventListenerData.ContainsKey(keyForOuterHashTable_string))
				{
					this.eventListenerData.Add(keyForOuterHashTable_string, new Hashtable());
				}

            //	INNER
            Hashtable inner_hashtable = this.eventListenerData[keyForOuterHashTable_string] as Hashtable;
				EventListenerData eventListenerData = new EventListenerData(aIEventListener, eventName, eventDelegate, eventDispatcherAddMode);
				//
				string keyForInnerHashTable_string = _getKeyForInnerHashTable(eventListenerData);
				if (inner_hashtable.Contains(keyForInnerHashTable_string))
				{

					//THIS SHOULD *NEVER* HAPPEN - REMOVE AFTER TESTED WELL
					Debug.Log("TODO (FIX THIS): Event Manager: Listener: " + keyForInnerHashTable_string + " is already in list for event: " + keyForOuterHashTable_string);

				}
				else
				{

					//	ADD
					inner_hashtable.Add(keyForInnerHashTable_string, eventListenerData);
					wasSuccessful_boolean = true;
					//Debug.Log ("	ADDED AT: " + keyForInnerHashTable_string + " = " +  eventListenerData);
				}

			}
			return wasSuccessful_boolean;
		}

		public bool HasEventListener(string eventName, EventDelegate eventDelegate)
		{
			//
			bool hasEventListener_boolean = false;

			//
			object aIEventListener = _getArgumentsCallee(eventDelegate);

			//	OUTER
			string keyForOuterHashTable_string = _getKeyForOuterHashTable(eventName);
			if (eventListenerData.ContainsKey(keyForOuterHashTable_string))
			{

				//	INNER
				Hashtable inner_hashtable = eventListenerData[keyForOuterHashTable_string] as Hashtable;
				string keyForInnerHashTable_string = _getKeyForInnerHashTable(new EventListenerData(aIEventListener, eventName, eventDelegate, EventDispatcherAddMode.DEFAULT));
				//
				if (inner_hashtable.Contains(keyForInnerHashTable_string))
				{
					hasEventListener_boolean = true;
				}
			}

			return hasEventListener_boolean;
		}

		public bool RemoveEventListener(string eventName, EventDelegate eventDelegate)
		{
			//
			bool wasSuccessful_boolean = false;

			//
			if (HasEventListener(eventName, eventDelegate))
			{
				//	OUTER
				string keyForOuterHashTable_string = _getKeyForOuterHashTable(eventName);
				Hashtable inner_hashtable = eventListenerData[keyForOuterHashTable_string] as Hashtable;
				//
				object aIEventListener = _getArgumentsCallee(eventDelegate);
				//  INNER
				string keyForInnerHashTable_string = _getKeyForInnerHashTable(new EventListenerData(aIEventListener, eventName, eventDelegate, EventDispatcherAddMode.DEFAULT));
				inner_hashtable.Remove(keyForInnerHashTable_string);
				wasSuccessful_boolean = true;
			}

			return wasSuccessful_boolean;

		}
		public bool RemoveAllEventListeners()
		{
			//
			bool wasSuccessful_boolean = false;

			//TODO, IS IT A MEMORY LEAK TO JUST RE-CREATE THE TABLE? ARE THE INNER HASHTABLES LEAKING?
			eventListenerData = new Hashtable();

			return wasSuccessful_boolean;
		}

		public bool DispatchEvent(IEvent aIEvent)
		{
			bool wasSuccessful_boolean = false;

			//
			_doAddTargetValueToIEvent(aIEvent);

			//	OUTER
			string keyForOuterHashTable_string = _getKeyForOuterHashTable(aIEvent.Type);
			int dispatchedCount_int = 0;
			if (eventListenerData.ContainsKey(keyForOuterHashTable_string))
			{

            //	INNER
            Hashtable inner_hashtable = this.eventListenerData[keyForOuterHashTable_string] as Hashtable;
				IEnumerator innerHashTable_ienumerator = inner_hashtable.GetEnumerator();
				DictionaryEntry dictionaryEntry;
				EventListenerData eventListenerData;
				ArrayList toBeRemoved_arraylist = new ArrayList();
				//
				while (innerHashTable_ienumerator.MoveNext())
				{

					dictionaryEntry = (DictionaryEntry)innerHashTable_ienumerator.Current;
					eventListenerData = dictionaryEntry.Value as EventListenerData;

					//***DO THE DISPATCH***
					//Debug.Log ("DISPATCH : ");
					//Debug.Log ("	n    : " + eventListenerData.eventName );
					//Debug.Log ("	from : " + aIEvent.target );
					//Debug.Log ("	to   : " + eventListenerData.eventListener );
					//Debug.Log ("	del  : " + eventListenerData.eventDelegate + " " + (eventListenerData.eventDelegate as System.Delegate).Method.DeclaringType.Name + " " + (eventListenerData.eventDelegate as System.Delegate).Method.Name.ToString());
					eventListenerData.EventDelegate(aIEvent);


					//TODO - THIS IS PROBABLY FUNCTIONAL BUT NOT OPTIMIZED, MY APPROACH TO HOW/WHY SINGLE SHOTS ARE REMOVED
					//REMOVE IF ONESHOT
					if (eventListenerData.EventListeningMode == EventDispatcherAddMode.SINGLE_SHOT)
					{

						toBeRemoved_arraylist.Add(eventListenerData);
					}

					//MARK SUCCESS, BUT ALSO CONTINUE LOOPING TOO
					wasSuccessful_boolean = true;
					dispatchedCount_int++;
				}

				//CLEANUP ANY ONE-SHOT, SINGLE-USE 
				EventListenerData toBeRemoved_eventlistenerdata;
				for (int count_int = toBeRemoved_arraylist.Count - 1; count_int >= 0; count_int--)
				{
					toBeRemoved_eventlistenerdata = toBeRemoved_arraylist[count_int] as EventListenerData;
					RemoveEventListener(toBeRemoved_eventlistenerdata.EventName, toBeRemoved_eventlistenerdata.EventDelegate);
				}

			}

			return wasSuccessful_boolean;
		}

		public void _doAddTargetValueToIEvent(IEvent aIEvent)
		{
			aIEvent.Target = _target;
		}

		private string _getKeyForOuterHashTable(string aEventName_string)
		{
			//SIMPLY USING THE EVENT NAME - METHOD USED HERE, IN CASE I WANT TO TWEAK THIS MORE...
			return aEventName_string;
		}

		private string _getKeyForInnerHashTable(EventListenerData aEventListenerData)
		{
			//VERY UNIQUE - NICE!
			return aEventListenerData.EventListener.GetType().FullName + "_" + aEventListenerData.EventListener.GetType().GUID + "_" + aEventListenerData.EventName + "_" + (aEventListenerData.EventDelegate as System.Delegate).Method.Name.ToString();
		}

		public object _getArgumentsCallee(EventDelegate aEventDelegate)
		{
			return (aEventDelegate as System.Delegate).Target;
		}

	}
}
