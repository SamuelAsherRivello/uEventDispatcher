﻿using UnityEngine;
using UnityEngine.Events;

namespace RMC.Core.UEvents.Assets
{
   [CreateAssetMenu(fileName = "UEventAsset", menuName = "RMC/UEvents/UEventAsset", order = 0)]
   public class UEventAsset : ScriptableObject, IUEvent
   {
      //  Fields ---------------------------------------
      private UEvent _uEvent = null;

      //  Unity Methods   -------------------------------
      protected void OnEnable()
      {
         _uEvent = new UEvent();

      }

      //  Methods   -------------------------------
      public void AddListener(UnityAction<UEventData> unityAction)
      {
         _uEvent.AddListener(unityAction);
      }

      public void Invoke()
      {
         _uEvent.Invoke(null);
      }

      public void Invoke(UEventData uEventData)
      {
         _uEvent.Invoke(uEventData);
      }

      public void RemoveAllListeners()
      {
         _uEvent.RemoveAllListeners();
      }

      public void RemoveListener(UnityAction<UEventData> unityAction)
      {
         _uEvent.RemoveListener(unityAction);
      }
   }
}