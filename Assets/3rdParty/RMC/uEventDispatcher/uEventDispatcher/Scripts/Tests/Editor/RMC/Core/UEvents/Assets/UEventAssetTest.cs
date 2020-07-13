
using NUnit.Framework;
using RMC.Core.UEvents.Assets;
using UnityEngine;

namespace RMC.Core.UEvents
{
   public class UEventAssetTest
   {
      private class TestUEvent01 : UEvent { };
      private class TestUEvent02 : UEvent { };

      [Test]
      public void Listener_WasNotCalled_WhenNotInvoked()
      {
         // Arrange
         var uEventAsset = ScriptableObject.CreateInstance<UEventAsset>();
         bool wasCalled = false;

         // Act
         uEventAsset.AddListener((IUEventData uEventData) =>
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
         var uEventAsset = ScriptableObject.CreateInstance<UEventAsset>();
         bool wasCalled = false;

         uEventAsset.AddListener((IUEventData uEventData) =>
         {
            wasCalled = true;
         });

         // Act
         uEventAsset.Invoke(new UEventData());

         // Assert
         Assert.That(wasCalled, Is.True);
      }
   }
}
