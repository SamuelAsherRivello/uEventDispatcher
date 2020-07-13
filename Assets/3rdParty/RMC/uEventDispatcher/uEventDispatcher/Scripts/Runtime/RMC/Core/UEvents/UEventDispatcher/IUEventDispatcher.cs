using RMC.Core.UEvents.Assets;
using UnityEngine.Events;

namespace RMC.Core.UEvents.UEventDispatcher
{
	public interface IUEventDispatcher
	{
      //  Methods --------------------------------
      void Invoke<T>(IUEventData uEventData) where T : IUEvent;
      void AddEventListener<T>(UnityAction<IUEventData> unityAction) where T : IUEvent;
      void RemoveAllListeners();
      void RemoveListener<T>(UnityAction<IUEventData> unityAction) where T : IUEvent;
   }
}
