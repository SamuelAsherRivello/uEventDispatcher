using UnityEngine;
using UnityEngine.Events;

namespace RMC.Core.UEvents.UEventDispatcher.Assets
{
   [CreateAssetMenu(fileName = "UEventDispatcherAsset", menuName = "RMC/UEvents/UEventDispatcherAsset", order = 0)]
   public class UEventDispatcherAsset : ScriptableObject, IUEventDispatcherAsset
   {
      //  Fields ---------------------------------------
      private UEvents.UEventDispatcher.UEventDispatcher _eventDispatcher = null;

      //  Unity Methods   -------------------------------
      protected void OnEnable()
      {
         _eventDispatcher = new UEvents.UEventDispatcher.UEventDispatcher();
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