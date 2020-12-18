//=========== Copyright (c) GameBuilders, All rights reserved. ================//

using UnityEditor;
using UnityEngine;
using System;

namespace DontStop.Editor
{
    [CustomPropertyDrawer(typeof(RequiredAttribute))]
    internal sealed class RequiredPropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var notnull = attribute as RequiredAttribute;
            var searchStr = "/Scripts/EditorResources/";
            var name = "warnIcon.png";

            if (property.objectReferenceValue == null && property.propertyType == SerializedPropertyType.ObjectReference)
            {
                var str = string.Empty; ;
                
                foreach (string assetPath in AssetDatabase.GetAllAssetPaths())
                {
                    if (!assetPath.Contains(searchStr))
                        continue;

                    str = assetPath;
                    str = str.Substring(0, str.LastIndexOf(searchStr, StringComparison.Ordinal) + searchStr.Length);
                    break;
                }

                Texture2D warnIcon = AssetDatabase.LoadAssetAtPath<Texture2D>(str + name);
                GUIContent content;

                if (warnIcon != null)
                {
                    content = new GUIContent(label.text, warnIcon, notnull != null && notnull.overrideMessage ? notnull.message : "The field " + property.displayName + " can not be null");
                }
                else
                {
                    content = new GUIContent("*" + label.text, notnull != null && notnull.overrideMessage ? notnull.message : "The field " + property.displayName + " can not be null");
                }

                EditorGUI.PropertyField(position, property, content);
            }
            else
            {
                EditorGUI.PropertyField(position, property, label);
            }
        }
    }
}
