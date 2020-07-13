using UnityEngine.Events;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace RMC.Core.UEvents.UEventDispatcher
{
	public class UEventDispatcher : IUEventDispatcher
	{
      //  Fields ---------------------------------------
      private Dictionary<Type, UEvent> _uEvents = null;

		//  Initialization -------------------------------
		public UEventDispatcher()
		{
         _uEvents = new Dictionary<Type, UEvent>();
      }

      //  Methods --------------------------------

      public void Invoke<T>(IUEventData uEventData) where T : UEvent
      {
         UEvent uEvent = _getUEvent<T>();
         if (uEvent != null)
         {
            uEvent.Invoke(uEventData);
         }
      }

      private UEvent _getUEvent<T>() where T : UEvent
      {
         UEvent uEvent = null;
         _uEvents.TryGetValue(typeof(T), out uEvent);
         return uEvent;
      }

      public void AddEventListener<T>(UnityAction<IUEventData> unityAction) where T : UEvent
      {
         UEvent uEvent = _getUEvent<T>();

         if (uEvent == null)
         {
            uEvent = Activator.CreateInstance<T>();
            _uEvents.Add(typeof(T), uEvent);
         }

         uEvent.AddListener(unityAction);
      }
      public void RemoveAllListeners()
      {
         foreach (KeyValuePair<Type, UEvent> entry in _uEvents)
         {
            entry.Value.RemoveAllListeners();
         }
         _uEvents.Clear();
      }

      public void RemoveListener<T>(UnityAction<IUEventData> unityAction) where T : UEvent
      {
         UEvent uEvent = _getUEvent<T>();
         if (uEvent != null)
         {
            uEvent.RemoveListener(unityAction);
         }
      }
   }
}
