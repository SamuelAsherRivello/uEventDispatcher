using NUnit.Framework;
using System;

namespace RMC.Core.UEvents.UEventDispatcher
{
   public class UEventDispatcherTest
   {
      private class TestUEvent01 : UEvent { };
      private class TestUEvent02 : UEvent { };

      [Test]
      public void Listener_WasNotCalled_WhenNotInvoked()
      {
         // Arrange
         var uEventDispatcher = new UEventDispatcher();
         bool wasCalled = false;

         // Act
         uEventDispatcher.AddEventListener<TestUEvent01>((IUEventData uEventData) =>
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
         var uEventDispatcher = new UEventDispatcher();
         bool wasCalled = false;

         uEventDispatcher.AddEventListener<TestUEvent01>((IUEventData uEventData) =>
         {
            wasCalled = true;
         });

         // Act
         uEventDispatcher.Invoke<TestUEvent01>(new UEventData());

         // Assert
         Assert.That(wasCalled, Is.True);
      }
   }
}
