using RMC.Core.UEvents.EventDispatcher;
using UnityEngine;

namespace RMC.Core.UEvents
{
   [CreateAssetMenu(fileName = "EventAsset", menuName = "RMC/UEvents/EventAsset", order = 0)]
   public class EventDispatcherAsset : ScriptableObject, IEventDispatcherAsset
   {
      //  Fields ---------------------------------------
      private EventDispatcher.EventDispatcher _eventDispatcher = null;

      //  Unity Methods   -------------------------------
      protected void OnEnable()
      {
         _eventDispatcher = new EventDispatcher.EventDispatcher(this);
      }

      //  Methods   -------------------------------
      public bool AddEventListener(string type, EventDelegate eventDelegate)
      {
         return _eventDispatcher.AddEventListener(type, eventDelegate);
      }

      public bool AddEventListener(string type, EventDelegate eventDelegate, EventDispatcherAddMode eventDispatcherAddMode)
      {
         return _eventDispatcher.AddEventListener(type, eventDelegate, eventDispatcherAddMode);
      }

      public bool DispatchEvent(IEvent iEvent)
      {
         return _eventDispatcher.DispatchEvent(iEvent);
      }

      public bool HasEventListener(string type, EventDelegate eventDelegate)
      {
         return _eventDispatcher.HasEventListener(type, eventDelegate);
      }

      public bool RemoveAllEventListeners()
      {
         return _eventDispatcher.RemoveAllEventListeners();
      }

      public bool RemoveEventListener(string type, EventDelegate eventDelegate)
      {
         return _eventDispatcher.RemoveEventListener(type, eventDelegate);
      }
   }
}