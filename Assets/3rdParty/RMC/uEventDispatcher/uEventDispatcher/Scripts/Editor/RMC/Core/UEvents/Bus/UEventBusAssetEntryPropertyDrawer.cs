﻿using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace RMC.Core.UEvents.Bus
{
   [CustomPropertyDrawer(typeof(UEventBusAssetEntry), true)]
   public class UEventBusAssetEntryPropertyDrawer : PropertyDrawer
   {
      //  Unity Methods ---------------------------------------
      public override VisualElement CreatePropertyGUI(SerializedProperty property)
      {
         // Create property fields.
         var _fromUEventAsset = new PropertyField(
            property.FindPropertyRelative("_fromUEventAsset"), "From");

         var _toUEventAsset = new PropertyField(
            property.FindPropertyRelative("_toUEventAsset"), "To");

         // Create property container element.
         var container = new VisualElement();
         container.style.flexDirection = FlexDirection.Row; 
 
         // Add fields to the container.
         container.Add(_fromUEventAsset);
         container.Add(_toUEventAsset);

         //We bind to the new SerializedObject
         container.Bind(property.serializedObject);

         return container;
      }
   }
}