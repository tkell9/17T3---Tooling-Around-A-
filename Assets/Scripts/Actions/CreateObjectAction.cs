using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObjectAction : Action
{
    public CreateObjectData actionData;

    public override void UndertakeAction()
    {
        if (actionData == null)
            return;

        if(actionData.prefab == null)
        {
            return;
        }


        if(actionData.parent == null)
        {
            Instantiate(actionData.prefab, actionData.location, Quaternion.identity);
        }
        else
        {
            Instantiate(actionData.prefab, actionData.location, Quaternion.identity, actionData.parent.transform);
        }
        

        HasActionCompleted = true;
    }

    public override ActionSetupData RequestBlankData()
    {
        return new CreateObjectData();
    }

    public override void SetActionData(ActionSetupData data)
    {
        actionData = (CreateObjectData)data;
    }
}
