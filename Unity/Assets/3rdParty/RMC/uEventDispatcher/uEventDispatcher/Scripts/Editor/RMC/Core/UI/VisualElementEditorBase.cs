using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace RMC.Core.UI
{
   /// <summary>
   /// Visual Elemement Propery Drawer (Editor)
   /// </summary>
   [CanEditMultipleObjects]
   [CustomEditor(typeof(UnityEngine.Object), true, isFallback = true)]
   public class VisualElementEditorBase : Editor
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
}
 