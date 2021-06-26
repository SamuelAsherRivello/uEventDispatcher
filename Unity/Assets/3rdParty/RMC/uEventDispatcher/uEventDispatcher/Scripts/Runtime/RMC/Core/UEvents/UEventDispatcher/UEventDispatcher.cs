using UnityEngine.Events;
using System;
using System.Collections.Generic;

namespace RMC.Core.UEvents.UEventDispatcher
{
	public class UEventDispatcher : IUEventDispatcher
	{
      //  Fields ---------------------------------------
      private Dictionary<Type, IUEvent> _uEvents = null;

		//  Initialization -------------------------------
		public UEventDispatcher()
		{
         _uEvents = new Dictionary<Type, IUEvent>();
      }

      //  Methods --------------------------------

      public void Invoke<T>(IUEventData uEventData) where T : IUEvent
      {
         IUEvent uEvent = _getUEvent<T>();
         if (uEvent != null)
         {
            uEvent.Invoke(uEventData);
         }
      }

      private IUEvent _getUEvent<T>() where T : IUEvent
      {
         IUEvent uEvent = null;
         _uEvents.TryGetValue(typeof(T), out uEvent);
         return uEvent;
      }

      public void AddEventListener<T>(UnityAction<IUEventData> unityAction) where T : IUEvent
      {
         IUEvent uEvent = _getUEvent<T>();

         if (uEvent == null)
         {
            uEvent = Activator.CreateInstance<T>();
            _uEvents.Add(typeof(T), uEvent);
         }

         uEvent.AddListener(unityAction);
      }
      public void RemoveAllListeners()
      {
         foreach (KeyValuePair<Type, IUEvent> entry in _uEvents)
         {
            entry.Value.RemoveAllListeners();
         }
         _uEvents.Clear();
      }

      public void RemoveListener<T>(UnityAction<IUEventData> unityAction) where T : IUEvent
      {
         IUEvent uEvent = _getUEvent<T>();
         if (uEvent != null)
         {
            uEvent.RemoveListener(unityAction);
         }
      }
   }
}
