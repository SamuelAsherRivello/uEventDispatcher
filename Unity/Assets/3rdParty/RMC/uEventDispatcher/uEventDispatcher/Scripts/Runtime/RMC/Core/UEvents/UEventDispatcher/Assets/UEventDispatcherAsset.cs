using UnityEngine;
using UnityEngine.Events;

namespace RMC.Core.UEvents.UEventDispatcher.Assets
{
   [CreateAssetMenu(fileName = "UEventDispatcherAsset", menuName = "RMC/UEvents/UEventDispatcherAsset", order = 0)]
   public class UEventDispatcherAsset : ScriptableObject, IUEventDispatcherAsset
   {
      //  Fields ---------------------------------------
      private UEventDispatcher _uEventDispatcher = null;

      //  Unity Methods   -------------------------------
      protected void OnEnable()
      {
         _uEventDispatcher = new UEvents.UEventDispatcher.UEventDispatcher();
      }

      //  Methods   -------------------------------
      public void Invoke<T>(IUEventData uEventData) where T : IUEvent
      {
         _uEventDispatcher.Invoke<T>(uEventData);
      }

      public void AddEventListener<T>(UnityAction<IUEventData> unityAction) where T : IUEvent
      {
         _uEventDispatcher.AddEventListener<T>(unityAction);
      }

      public void RemoveAllListeners()
      {
         _uEventDispatcher.RemoveAllListeners();
      }

      public void RemoveListener<T>(UnityAction<IUEventData> unityAction) where T : IUEvent
      {
         _uEventDispatcher.RemoveListener<T>(unityAction);
      }
   }
}