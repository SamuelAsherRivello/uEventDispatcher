using NUnit.Framework;
using RMC.Core.UEvents.UEventDispatcher.Assets;
using System;
using UnityEngine;

namespace RMC.Core.UEvents.UEventDispatcher
{
   public class UEventDispatcherAssetTest
   {
      private class TestUEvent01 : UEvent { };
      private class TestUEvent02 : UEvent { };

      [Test]
      public void Listener_WasNotCalled_WhenNotInvoked()
      {
         // Arrange
         var uEventDispatcherAsset = ScriptableObject.CreateInstance<UEventDispatcherAsset>();
         bool wasCalled = false;

         // Act
         uEventDispatcherAsset.AddEventListener<TestUEvent01>((IUEventData uEventData) =>
         {
            wasCalled = true;
         });

         // Assert
         Assert.That(wasCalled, Is.False);
      }

      [Test]
      public void Listener_WasCalled_WhenInvoked()
      {
         // Arrange
         var uEventDispatcherAsset = ScriptableObject.CreateInstance<UEventDispatcherAsset>();
         bool wasCalled = false;

         uEventDispatcherAsset.AddEventListener<TestUEvent01>((IUEventData uEventData) =>
         {
            wasCalled = true;
         });

         // Act
         uEventDispatcherAsset.Invoke<TestUEvent01>(new UEventData());

         // Assert
         Assert.That(wasCalled, Is.True);
      }
   }
}
