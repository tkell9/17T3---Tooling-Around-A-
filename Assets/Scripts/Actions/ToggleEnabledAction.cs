using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleEnabledAction : Action
{
    public ToggleEnabledData actionData;

    public override void UndertakeAction()
    {
        if (actionData == null)
        {
            return;
        }


        if (actionData.toggleSelf)
        {
            gameObject.SetActive(!gameObject.activeInHierarchy);
        }

        if (actionData.toggleObject != null)
        {
            actionData.toggleObject.SetActive(!actionData.toggleObject.activeInHierarchy);
        }

        if (actionData.toggleComponent != null)
        {
            actionData.toggleComponent.enabled = !actionData.toggleComponent.enabled;
        }

        HasActionCompleted = true;
    }

    public override ActionSetupData RequestBlankData()
    {
        return new ToggleEnabledData();
    }

    public override void SetActionData(ActionSetupData data)
    {
        actionData = (ToggleEnabledData)data;
    }
}
