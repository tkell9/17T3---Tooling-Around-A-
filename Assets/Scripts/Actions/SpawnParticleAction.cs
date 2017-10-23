using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnParticleAction : Action
{
    public SpawnParticleData actionData;

    public override void UndertakeAction()
    {
        if (actionData == null)
        {
            return;
        }


        if (actionData.particleEffect == null)
        {
            return;
        }
            

        Vector3 spawnLoc;

        if(actionData.spawnOnSelf)
        {
            spawnLoc = gameObject.transform.position;
        }
        else
        {
            spawnLoc = actionData.spawnLocation;
        }

        Instantiate(actionData.particleEffect.gameObject, spawnLoc, Quaternion.identity);

        HasActionCompleted = true;
    }

    public override ActionSetupData RequestBlankData()
    {
        return new SpawnParticleData();
    }

    public override void SetActionData(ActionSetupData data)
    {
        actionData = (SpawnParticleData)data;
    }
}
