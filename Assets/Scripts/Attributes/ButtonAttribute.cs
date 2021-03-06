﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class ButtonAttribute : PropertyAttribute {
	public string methodName;
	public string buttonName;
	public bool useValue;
	public BindingFlags flags;

	public ButtonAttribute(string methodName, string buttonName, bool useValue, BindingFlags flags = BindingFlags.Public | BindingFlags.Instance) {
		this.methodName = methodName;
		this.buttonName = buttonName;
		this.useValue = useValue;
		this.flags = flags;
	}
	public ButtonAttribute(string methodName, bool useValue, BindingFlags flags) : this (methodName, methodName, useValue, flags) {}
	public ButtonAttribute(string methodName, bool useValue) : this (methodName, methodName, useValue) {}
	public ButtonAttribute(string methodName, string buttonName, BindingFlags flags) : this (methodName, buttonName, false, flags) {}
	public ButtonAttribute(string methodName, string buttonName) : this (methodName, buttonName, false) {}
	public ButtonAttribute(string methodName, BindingFlags flags) : this (methodName, methodName, false, flags) {}
	public ButtonAttribute(string methodName) : this (methodName, methodName, false) {}
}

#if UNITY_EDITOR
[CustomPropertyDrawer(typeof(ButtonAttribute))]
public class ButtonDrawer : PropertyDrawer {
	ButtonAttribute battribute;
	Object obj;
	Rect buttonRect;
	Rect valueRect;

	public override void OnGUI (Rect position, SerializedProperty property, GUIContent label) {
		battribute = attribute as ButtonAttribute;
		obj = property.serializedObject.targetObject;
		MethodInfo method = obj.GetType().GetMethod(battribute.methodName, battribute.flags);

		if (method == null) {
			EditorGUI.HelpBox(position, "Method Not Found", MessageType.Error);

		} else {
			if (battribute.useValue) {
				valueRect = new Rect(position.x, position.y, position.width/2f, position.height);
				buttonRect = new Rect(position.x + position.width/2f, position.y, position.width/2f, position.height);

				EditorGUI.PropertyField(valueRect, property, GUIContent.none);
				if (GUI.Button(buttonRect, battribute.buttonName)) {
					method.Invoke(obj, new object[]{fieldInfo.GetValue(obj)});
				}

			} else {
				if (GUI.Button(position, battribute.buttonName)) {
					method.Invoke(obj, null);
				}
			}
		}
	}
}
#endif
 
