
using NUnit.Framework;
using RMC.Core.UEvents.Assets;
using UnityEngine;

namespace RMC.Core.UEvents
{
   public class UEventAssetListenerTest
   {
      private class TestUEvent01 : UEvent { };
      private class TestUEvent02 : UEvent { };

      private GameObject _gameObject = null;

      [TearDown]
      public void OnTearDown()
      {
         if (_gameObject != null)
         {
            GameObject.DestroyImmediate(_gameObject);
            _gameObject = null;
         }
      }


      [Test]
      public void Listener_WasNotCalled_WhenNotInvoked()
      {
         // Arrange
         var uEventAsset = ScriptableObject.CreateInstance<UEventAsset>();
         bool wasCalled = false;

         _gameObject = new GameObject();
         var uEventAssetListener = _gameObject.AddComponent<UEventAssetListener>();
         uEventAssetListener.UEventAsset = uEventAsset;

         // Act
         uEventAssetListener.UEvent.AddListener((IUEventData uEventData) =>
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

         _gameObject = new GameObject();
         var uEventAssetListener = _gameObject.AddComponent<UEventAssetListener>();
         uEventAssetListener.UEventAsset = uEventAsset;

         uEventAssetListener.UEvent.AddListener((IUEventData uEventData) =>
         {
            wasCalled = true;
         });

         // Act
         uEventAsset.Invoke(new UEventData());

         // Assert
         Assert.That(wasCalled, Is.False);
      }
   }
}
