using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Condition : MonoBehaviour {

    public string Name;
    public bool isConditionFulfilled;
    //public ConditionSetUpData Data;

    public List<Action> actions = new List<Action>();

    public bool happenOnlyOnce = false;
    public bool alreadyHappened = false;

    public bool filterByTag = false;
    public List<string> filterTags = new List<string>();

    public void ExecuteAllActions()
    {
        if (happenOnlyOnce && alreadyHappened)
            return;

        foreach(Action act in actions)
        {
            act.UndertakeAction();
        }

        alreadyHappened = true;
    }

    public virtual bool HasConditionBeenFulfilled()
    {
        if (isConditionFulfilled)
        {
            return true;
        }

        return false;
    }

    public virtual void ResetCondition()
    {
        isConditionFulfilled = false;
    }

    public abstract ConditionSetUpData RequestBlankData();
    public abstract void SetConditionData(ConditionSetUpData data);
}
