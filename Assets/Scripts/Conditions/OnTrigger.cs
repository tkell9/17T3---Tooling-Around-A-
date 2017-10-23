using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTrigger : Condition
{
    public OnTriggerData condititionData;

    // Use this for initialization
    void Start () {
        condititionData.lastTimeTriggerStay = -condititionData.frequency;
	}

    private void OnTriggerEnter(Collider other)
    {
        if(condititionData.eventType == OnTriggerData.ColliderEventTypes.Enter)
        {
            isConditionFulfilled = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (Time.time >= condititionData.lastTimeTriggerStay + condititionData.frequency && condititionData.eventType == OnTriggerData.ColliderEventTypes.StayInside)
        {
            isConditionFulfilled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (condititionData.eventType == OnTriggerData.ColliderEventTypes.Exit)
        {
            isConditionFulfilled = true;
        }
    }

    public override void ResetCondition()
    {
        base.ResetCondition();
        condititionData.lastTimeTriggerStay = Time.time;
    }


    public override ConditionSetUpData RequestBlankData()
    {
        return new OnTriggerData();
    }

    public override void SetConditionData(ConditionSetUpData data)
    {
        condititionData = (OnTriggerData)data;
    }
}
