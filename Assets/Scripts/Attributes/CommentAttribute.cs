using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System.Collections;

public class CommentAttribute : PropertyAttribute {
	public readonly string tooltip;
	public readonly string comment;

	public CommentAttribute( string comment, string tooltip ) {
		this.tooltip = tooltip;
		this.comment = comment;
	}
}

#if UNITY_EDITOR
[CustomPropertyDrawer(typeof(CommentAttribute))]
public class CommentDrawer : DecoratorDrawer {
	const int textHeight = 20;

	CommentAttribute commentAttribute { get { return (CommentAttribute)attribute; } }

	public override float GetHeight(){
		return textHeight;
	}

	public override void OnGUI (Rect position)
	{
		EditorGUI.LabelField(position,new GUIContent(commentAttribute.comment,commentAttribute.tooltip));
	}
}
#endif