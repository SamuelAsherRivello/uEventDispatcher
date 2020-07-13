using NUnit.Framework;
using System;

namespace RMC.Core.UEvents.EventDispatcher
{
   public class TestUEvent01 : UEvent { };
   public class TestUEvent02 : UEvent { };

   public class UEventDispatcherTest
   {
      [Test]
      public void Listener_WasNotCalled_WhenNotInvoked()
      {
         // Arrange
         var uEventDispatcher = new UEventDispatcher();
         bool wasCalled = false;

         // Act
         uEventDispatcher.AddEventListener<TestUEvent01>((UEventData uEventData) =>
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

         uEventDispatcher.AddEventListener<TestUEvent01>((UEventData uEventData) =>
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
