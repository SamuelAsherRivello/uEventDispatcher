using System;
using UnityEngine;

namespace RMC.Core.Singleton.Examples
{
   public class SingletonMonoBehaviourExample : SingletonMonobehavior<SingletonMonoBehaviourExample>
   {
      public void SayHelloWorld()
      {
         Debug.Log($"{this.GetType().Name} Hello World!");
      }
   }
}