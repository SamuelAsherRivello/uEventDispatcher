using UnityEngine.Events;

namespace RMC.Core.UEvents.Assets
{
   public interface IUEvent
   {
      //  Methods   -------------------------------
      void AddListener(UnityAction<IUEventData> unityAction);
      void Invoke();
      void Invoke(IUEventData uEventData);
      void RemoveAllListeners();
      void RemoveListener(UnityAction<IUEventData> unityAction);
   }
}