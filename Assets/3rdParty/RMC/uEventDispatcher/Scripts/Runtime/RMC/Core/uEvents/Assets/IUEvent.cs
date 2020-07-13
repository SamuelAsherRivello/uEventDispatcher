using UnityEngine.Events;

namespace RMC.Core.UEvents.Assets
{
   public interface IUEvent
   {
      //  Methods   -------------------------------
      void AddListener(UnityAction<UEventData> unityAction);
      void Invoke();
      void Invoke(UEventData uEventData);
      void RemoveAllListeners();
      void RemoveListener(UnityAction<UEventData> unityAction);
   }
}