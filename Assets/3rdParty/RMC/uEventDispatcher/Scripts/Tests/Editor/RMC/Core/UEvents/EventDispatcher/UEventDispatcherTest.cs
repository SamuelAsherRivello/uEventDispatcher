using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using RMC.Core.UEvents;
using RMC.Core.UEvents.EventDispatcher;
using RMC.Core.UEvents.Examples;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
   public class UEventDispatcherTest
   {
      [Test]
      public void Event_IsNotCalled_WhenNotCalled()
      {
         // Arrange
         var uEventDispatcher = new UEventDispatcher(this);
         bool wasCalled = false;

         // Act
         uEventDispatcher.AddEventListener("test", (IEvent iEvent) =>
         {
            wasCalled = true;
         });

         // Assert
         Assert.That(wasCalled, Is.False);

      }

      [Test]
      public void Event_IsCalled_WhenCalled()
      {
         // Arrange
         var uEventDispatcher = new UEventDispatcher(this);
         bool wasCalled = false;

         uEventDispatcher.AddEventListener("test", (IEvent iEvent) =>
         {
            wasCalled = true;
         });

         // Act
         uEventDispatcher.DispatchEvent(new SampleEvent("test", null));

         // Assert
         Assert.That(wasCalled, Is.True);

      }
   }
}
