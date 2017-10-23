using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>
[System.Serializable]
public class ActionSetupData
{
    //the fuck is this for
    public enum ActionType
    {
        AddResource
    }

    private ActionType Type;
}

/// <summary>
/// 
/// </summary>
[System.Serializable]
public class AddResourceActionData : ActionSetupData
{
    //private new ActionType Type = ActionType.AddResource;
    public string ResourceToAdd;
    public float AdditionValue;
    public ResourcePool TargetPool;
    //public string TargetPoolIdentifier;
}

/// <summary>
/// 
/// </summary>
[System.Serializable]
public class CreateObjectData : ActionSetupData
{
    public GameObject prefab;
    public Vector3 location;
    public GameObject parent;
}

/// <summary>
/// 
/// </summary>
[System.Serializable]
public class LoadSceneData : ActionSetupData
{
    [Header("0 for reload this scene")]
    public string sceneName = "0";
}

/// <summary>
/// 
/// </summary>
[System.Serializable]
public class TeleportObjectData : ActionSetupData
{
    public bool teleportSelf;
    public Vector3 teleportLocation;
    public GameObject objectToTeleportTo;
}

/// <summary>
/// 
/// </summary>
[System.Serializable]
public class ToggleEnabledData : ActionSetupData 
{
    public bool toggleSelf;
    public GameObject toggleObject;
    public MonoBehaviour toggleComponent;
}

/// <summary>
/// 
/// </summary>
[System.Serializable]
public class DestroyObjectData : ActionSetupData
{

}

/// <summary>
/// 
/// </summary>
[System.Serializable] 
public class SpawnParticleData : ActionSetupData
{
    public ParticleSystem particleEffect;
    public bool spawnOnSelf;
    public Vector3 spawnLocation;
}

/// <summary>
/// 
/// </summary>
[System.Serializable] 
public class StateChangeData : ActionSetupData
{

}