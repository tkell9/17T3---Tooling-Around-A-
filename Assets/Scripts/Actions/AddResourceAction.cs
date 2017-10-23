using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddResourceAction : Action {
    public AddResourceActionData actionData;

    public override void UndertakeAction()
    {
        AddResourceActionData CastData = (AddResourceActionData)actionData;
        if (CastData == null)
            return;

        if (CastData.TargetPool.AvaliableResources.ContainsKey(CastData.ResourceToAdd))
        {
            float CurrentValue = CastData.TargetPool.AvaliableResources[CastData.ResourceToAdd];
            CastData.TargetPool.AvaliableResources[CastData.ResourceToAdd] = (CurrentValue + CastData.AdditionValue);
            Debug.Log(CastData.TargetPool.AvaliableResources[CastData.ResourceToAdd]);
        }
        HasActionCompleted = true;
    }

    public override ActionSetupData RequestBlankData()
    {
        return new AddResourceActionData();
    }

    public override void SetActionData(ActionSetupData data)
    {
        actionData = (AddResourceActionData)data;
    }


    ////This will be the create window editor.. maybe put this in it's own script... createdata class... or in ActionSetupData
    //public override AddResourceActionData RequestDataSetup()
    //{
    //    AddResourceActionData ActionData = ScriptableObject.CreateInstance<AddResourceActionData>();

    //    ActionData.ResourceToAdd = "Coal";
    //    ActionData.AdditionValue = 5;
    //    ActionData.TargetPool = FindObjectOfType<ResourcePool>();
    //    return ActionData;
    //}
}
