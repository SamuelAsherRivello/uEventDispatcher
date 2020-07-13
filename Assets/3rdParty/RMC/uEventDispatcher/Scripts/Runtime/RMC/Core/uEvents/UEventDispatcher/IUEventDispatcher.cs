using RMC.Core.UEvents.Assets;
using UnityEngine.Events;

namespace RMC.Core.UEvents.EventDispatcher
{
	public interface IUEventDispatcher
	{
      //  Methods --------------------------------
      void Invoke<T>(IUEventData uEventData) where T : UEvent;
      void AddEventListener<T>(UnityAction<IUEventData> unityAction) where T : UEvent;
      void RemoveAllListeners();
      void RemoveListener<T>(UnityAction<IUEventData> unityAction) where T : UEvent;
   }
}
