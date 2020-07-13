using NUnit.Framework;

namespace RMC.Core.UEvents
{
   public class TestUEvent01 : UEvent { };
   public class TestUEvent02 : UEvent { };

   public class UEventTest
   {
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
