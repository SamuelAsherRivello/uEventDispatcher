using RMC.Core.Attributes;
using System;
using System.Reflection;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace RMC.Core.UI
{
   [CanEditMultipleObjects]
   [CustomEditor(typeof(UnityEngine.Object), true, isFallback = true)]
   public class DefaultEditor : Editor
   {
      public override VisualElement CreateInspectorGUI()
      {
         var container = new VisualElement();

         var iterator = serializedObject.GetIterator();
         if (iterator.NextVisible(true))
         {
            do
            {
               var propertyField = new PropertyField(iterator.Copy())
               {
                  name = "PropertyField:" + iterator.propertyPath
               };

               if (iterator.propertyPath == "m_Script" && serializedObject.targetObject != null)
               {
                  propertyField.SetEnabled(value: false);
               }

               if (iterator.name == "testList")
               {
                  var test = CreateFoldout(iterator);
                  container.Add(test);
               }
               else
               {
                  container.Add(propertyField);
               }

            } while (iterator.NextVisible(false));
         }

         return container;
      }

      private VisualElement CreateFoldout(SerializedProperty property)
      {
         property = property.Copy();
         Foldout e = new Foldout();
         e.text = "TEST FOLDOUT";
         e.value = property.isExpanded;
         e.bindingPath = property.propertyPath;
         e.name = "unity-foldout-" + property.propertyPath;
         Label label = e.Q<Toggle>((string)null, Foldout.toggleUssClassName).Q<Label>((string)null, Toggle.textUssClassName);
         label.bindingPath = property.propertyPath;
         SerializedProperty endProperty = property.GetEndProperty();
         property.NextVisible(true);
         while (!SerializedProperty.EqualContents(property, endProperty))
         {
            PropertyField propertyField = new PropertyField(property);
            propertyField.name = "unity-property-field-" + property.propertyPath;
            if (propertyField != null)
               e.Add((VisualElement)propertyField);
            if (!property.NextVisible(false))
               break;
         }
         return (VisualElement)e;
      }
   }


   /// <summary>
   /// Visual Elemement Propery Drawer (Editor)
   /// </summary>
   public class VEPDEditorBase : Editor
   {
      public override VisualElement CreateInspectorGUI()
      {
         var container = new VisualElement();

         // Draw the legacy IMGUI base
         var imgui = new IMGUIContainer(OnInspectorGUI);
         container.Add(imgui);

         // Find all properties that are marked [HideInInspector] that have
         // a PropertyDrawer tagged with the [VEPropertyDrawer] attribute and create
         // PropertyFields for each of them.
         var type = target.GetType();
         // Create property fields.
         // Add fields to the container.
         CreatePropertyFields(container, type);
         return container;
      }

      protected void CreatePropertyFields(VisualElement container, Type objectType)
      {
         var fields = objectType.GetFields(
               BindingFlags.GetField | BindingFlags.Instance | BindingFlags.Public);
         foreach (var fieldInfo in fields)
         {
            var attr = fieldInfo.GetCustomAttribute<HideInInspector>();
            if (attr == null || !IsPropertyDrawerTagged(fieldInfo.FieldType))
               continue;

            container.Add(
                new PropertyField(serializedObject.FindProperty(fieldInfo.Name)));
         }
      }

      protected bool IsPropertyDrawerTagged(Type propertyType)
      {
         var drawerType = GetPropertyDrawerType(propertyType);
         if (drawerType == null)
            return false;

         var attrs = drawerType.GetCustomAttributes(
                             typeof(VEPDAttribute), true);
         return attrs.Length > 0;
      }


      /// <summary>
      /// Use Reflection to access ScriptAttributeUtility to find the
      /// PropertyDrawer type for a property type
      /// </summary>
      protected Type GetPropertyDrawerType(Type typeToDraw)
      {
         var scriptAttributeUtilityType = GetScriptAttributeUtilityType();

         var getDrawerTypeForTypeMethod =
                     scriptAttributeUtilityType.GetMethod(
                         "GetDrawerTypeForType",
                         BindingFlags.Static | BindingFlags.NonPublic, null,
                         new[] { typeof(Type) }, null);

         return (Type)getDrawerTypeForTypeMethod.Invoke(null, new[] { typeToDraw });
      }

      protected Type GetScriptAttributeUtilityType()
      {
         var asm = Array.Find(AppDomain.CurrentDomain.GetAssemblies(),
                                           (a) => a.GetName().Name == "UnityEditor");

         var types = asm.GetTypes();
         var type = Array.Find(types, (t) => t.Name == "ScriptAttributeUtility");

         return type;
      }
      public override void OnInspectorGUI()
      {
         DrawDefaultInspector();
      }

   }
}
 