using NUnit.Framework;

namespace RMC.Core.UEvents
{
   public class UEventTest
   {
      private class TestUEvent01 : UEvent { };
      private class TestUEvent02 : UEvent { };

      [Test]
      public void Listener_WasNotCalled_WhenNotInvoked()
      {
         // Arrange
         var uEvent = new UEvent();
         bool wasCalled = false;

         // Act
         uEvent.AddListener((IUEventData uEventData) =>
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
         var uEvent = new UEvent();
         bool wasCalled = false;

         uEvent.AddListener((IUEventData uEventData) =>
         {
            wasCalled = true;
         });

         // Act
         uEvent.Invoke(new UEventData());

         // Assert
         Assert.That(wasCalled, Is.True);
      }
   }
}