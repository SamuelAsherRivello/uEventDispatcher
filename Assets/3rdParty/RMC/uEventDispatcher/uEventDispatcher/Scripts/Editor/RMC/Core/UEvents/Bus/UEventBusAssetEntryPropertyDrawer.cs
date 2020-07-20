using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace RMC.Core.UEvents.Bus
{
   [CustomPropertyDrawer(typeof(UEventBusAssetEntry), true)]
   public class UEventBusAssetEntryPropertyDrawer : PropertyDrawer
   {
      //  Fields  ---------------------------------------
      private const string _ussPath = @"RMC\Core\UEvents\Bus\UEventBusAssetEntryPropertyDrawerStyles";
      private const string _uxmlPath = @"RMC\Core\UEvents\Bus\UEventBusAssetEntryPropertyDrawer";

      //  Unity Methods ---------------------------------------
      public override VisualElement CreatePropertyGUI(SerializedProperty property)
      {
         // Create property container element.
         var root = new VisualElement();
         root.styleSheets.Add(Resources.Load<StyleSheet>(_ussPath));

         //We bind to the new SerializedObject
         root.Bind(property.serializedObject);

         var quickToolVisualTree = Resources.Load<VisualTreeAsset>(_uxmlPath);
         quickToolVisualTree.CloneTree(root);

         var to = SetupPropertyField(root, property, "to", "_toUEventAsset", "To");
         var from = SetupPropertyField(root, property, "from", "_fromUEventAsset", "From");
         var delay = SetupPropertyField(root, property, "delay", "_delay", "Delay");

         return root;
      }

      private PropertyField SetupPropertyField(VisualElement root, SerializedProperty property, 
         string queryName, string propertyName, string labelText)
      {
         var to = root.Q<PropertyField>(queryName);
         to.BindProperty(property.FindPropertyRelative(propertyName));
         to.label = labelText;
         return to;
      }
   }
}
