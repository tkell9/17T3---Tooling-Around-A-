using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollision : Condition
{
    public OnCollisionData condititionData;

    private void OnCollisionEnter(Collision collision)
    {
        isConditionFulfilled = true;
    }



    public override ConditionSetUpData RequestBlankData()
    {
        return new OnCollisionData();
    }

    public override void SetConditionData(ConditionSetUpData data)
    {
        condititionData = (OnCollisionData)data;
    }
}
