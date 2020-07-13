using RMC.Core.UEvents.EventDispatcher;
using UnityEngine;
using UnityEngine.Events;

namespace RMC.Core.UEvents.Assets
{
   [CreateAssetMenu(fileName = "UEventDispatcherAsset", menuName = "RMC/UEvents/UEventDispatcherAsset", order = 0)]
   public class UEventDispatcherAsset : ScriptableObject, IUEventDispatcherAsset
   {
      //  Fields ---------------------------------------
      private EventDispatcher.UEventDispatcher _eventDispatcher = null;

      //  Unity Methods   -------------------------------
      protected void OnEnable()
      {
         _eventDispatcher = new EventDispatcher.UEventDispatcher();
      }

      //  Methods   -------------------------------
      public void Invoke<T>(IUEventData uEventData) where T : UEvent
      {
         _eventDispatcher.Invoke<T>(uEventData);
      }

      public void AddEventListener<T>(UnityAction<IUEventData> unityAction) where T : UEvent
      {
         _eventDispatcher.AddEventListener<T>(unityAction);
      }

      public void RemoveAllListeners()
      {
         _eventDispatcher.RemoveAllListeners();
      }

      public void RemoveListener<T>(UnityAction<IUEventData> unityAction) where T : UEvent
      {
         _eventDispatcher.RemoveListener<T>(unityAction);
      }
   }
}