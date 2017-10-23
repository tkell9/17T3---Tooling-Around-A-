using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>
[System.Serializable]
public abstract class ConditionSetUpData
{
    public enum ConditionType
    {
        ObjectOnTriggerEnter2D
    }
    private ConditionType Conditiontype;
    public List<string> ConcerningTags = new List<string>();
}


//WTF NOOOOOOOOO
[System.Serializable]
public class ObjectOnTriggerEnter2DConditionSetupData : ConditionSetUpData
{
    //public new ConditionType Conditiontype = ConditionType.ObjectOnTriggerEnter2D;
    public enum ColiderType { Box, Sphere, Capsule, Mesh, Wheel, Terrain }
    public ColiderType ObjectColider;
}

/// <summary>
/// 
/// </summary>
[System.Serializable]
public class OnTriggerData : ConditionSetUpData
{
    [System.Serializable]
    public enum ColliderEventTypes
    {
        Enter,
        Exit,
        StayInside
    }

    public float frequency = 1.0f;

    public ColliderEventTypes eventType = ColliderEventTypes.Enter;

    public float lastTimeTriggerStay;
}

/// <summary>
/// 
/// </summary>
[System.Serializable]
public class OnCollisionData : ConditionSetUpData
{

}

/// <summary>
/// 
/// </summary>
[System.Serializable]
public class OnKeyPressData : ConditionSetUpData
{
    [System.Serializable]
    public enum KeyEventTypes
    {
        JustPressed,
        Released,
        KeptPressed
    }

    public KeyCode keyValue;
    public KeyEventTypes eventType = KeyEventTypes.JustPressed;

    public float frequency = 1.0f;

    public float lastTimeEventFired;
}

/// <summary>
/// 
/// </summary>
[System.Serializable]
public class OnResourceValueData : ConditionSetUpData
{
    [System.Serializable]
    public enum ResourceCheckType
    {
        Greater,
        GreaterOrEqual,
        ExactlyEqual,
        LessOrEqual,
        Less
    }

    public ResourcePool pool;
    public string resourceName;

    public ResourceCheckType eventType = ResourceCheckType.ExactlyEqual;
    public int value = 0;
}