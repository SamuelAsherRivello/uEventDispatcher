using System;
using UnityEngine.Events;

namespace RMC.Core.UEvents
{
   [Serializable]
   public class UEvent : UnityEvent<IUEventData>
   {
   }
}