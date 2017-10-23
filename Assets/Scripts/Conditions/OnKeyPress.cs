using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnKeyPress : Condition
{
    public OnKeyPressData condititionData;

    private void Start()
    {
        condititionData.lastTimeEventFired = -condititionData.frequency;
    }

    private void Update()
    {
        switch(condititionData.eventType)
        {
            case OnKeyPressData.KeyEventTypes.JustPressed:
                if(Input.GetKeyDown(condititionData.keyValue))
                {
                    isConditionFulfilled = true;
                }
                break;
            case OnKeyPressData.KeyEventTypes.KeptPressed:
                if (Time.time >= condititionData.lastTimeEventFired + condititionData.frequency && Input.GetKey(condititionData.keyValue))
                {
                    isConditionFulfilled = true;
                    condititionData.lastTimeEventFired = Time.time;
                }
                break;
            case OnKeyPressData.KeyEventTypes.Released:
                if (Input.GetKeyUp(condititionData.keyValue))
                {
                    isConditionFulfilled = true;
                }
                break;
        }
    }

    public override ConditionSetUpData RequestBlankData()
    {
        return new OnKeyPressData();
    }

    public override void SetConditionData(ConditionSetUpData data)
    {
        condititionData = (OnKeyPressData)data;
    }
}
