using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnResourceValue : Condition
{
    public OnResourceValueData condititionData;


    private void Update()
    {
        //need to fetch the value
        int fetchedResourceValue = 0;

        switch(condititionData.eventType)
        {
            case OnResourceValueData.ResourceCheckType.Greater:
                if(fetchedResourceValue > condititionData.value)
                {
                    isConditionFulfilled = true;
                }
                break;
            case OnResourceValueData.ResourceCheckType.GreaterOrEqual:
                if (fetchedResourceValue >= condititionData.value)
                {
                    isConditionFulfilled = true;
                }
                break;
            case OnResourceValueData.ResourceCheckType.ExactlyEqual:
                if (fetchedResourceValue == condititionData.value)
                {
                    isConditionFulfilled = true;
                }
                break;
            case OnResourceValueData.ResourceCheckType.LessOrEqual:
                if (fetchedResourceValue <= condititionData.value)
                {
                    isConditionFulfilled = true;
                }
                break;
            case OnResourceValueData.ResourceCheckType.Less:
                if (fetchedResourceValue < condititionData.value)
                {
                    isConditionFulfilled = true;
                }
                break;
        }
    }

    public override ConditionSetUpData RequestBlankData()
    {
        return new OnResourceValueData();
    }

    public override void SetConditionData(ConditionSetUpData data)
    {
        condititionData = (OnResourceValueData)data;
    }
}
