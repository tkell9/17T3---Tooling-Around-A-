using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportObjectAction : Action
{
    public TeleportObjectData actionData;

    public override void UndertakeAction()
    {
        if (actionData == null)
        {
            return;
        }
            

        GameObject teleportObject;

        if (actionData.teleportSelf)
        {
            teleportObject = gameObject;
        }
        else
        {
            teleportObject = gameObject;
            //teleportObject = other;
        }

        if(actionData.objectToTeleportTo != null)
        {
            teleportObject.transform.position = actionData.objectToTeleportTo.transform.position;
        }
        else
        {
            teleportObject.transform.position = actionData.teleportLocation;
        }

        HasActionCompleted = true;
    }

    public override ActionSetupData RequestBlankData()
    {
        return new TeleportObjectData();
    }

    public override void SetActionData(ActionSetupData data)
    {
        actionData = (TeleportObjectData)data;
    }

}
