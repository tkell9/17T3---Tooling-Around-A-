using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour {

    public string Name;
    public bool IsInteractionUnderway;
    public List<string> ConcerningTags = new List<string>();

    public List<Condition> InteractionConditions = new List<Condition>();
    public List<Action> ActionsToUnderTake = new List<Action>();

    void Start () {
        SetupActions();
        SetupConditions();
    }
	
	void Update () {
		if(AreConditionsMet() && IsInteractionUnderway == false)
        {
            StartInteractions();
            if (CheckForActionCompletion())
            {
                IsInteractionUnderway = false;
                ResetConditions();
                ResetActions();
            }
        }
	}

    bool AreConditionsMet()
    {
        bool AreAllConditionsMet = true;
        foreach(Condition Con in InteractionConditions)
        {
            if (Con.HasConditionBeenFulfilled() == false)
                AreAllConditionsMet = false;
        }
        return AreAllConditionsMet;
    }

    void StartInteractions()
    {
        IsInteractionUnderway = true;
        foreach(Action ToDoAction in ActionsToUnderTake)
            if (ToDoAction.HasActionCompleted == false)
                ToDoAction.UndertakeAction();
    }

    bool CheckForActionCompletion()
    {
        bool AreAllActionsCompleted = true;
        foreach (Action ToDoAction in ActionsToUnderTake)
        {
            if (ToDoAction.HasActionCompleted == false)
                AreAllActionsCompleted = false;
        }
        return AreAllActionsCompleted;
    }

    void ResetActions()
    {
        foreach (Action ToDoAction in ActionsToUnderTake)
            if (ToDoAction.HasActionCompleted == true)
                ToDoAction.ResetAction();
    }

    void ResetConditions()
    {
        foreach (Condition Con in InteractionConditions)
            Con.ResetCondition();
    }

    void SetupActions()
    {
        foreach (Action ToDoAction in ActionsToUnderTake)
        {
            ActionSetupData ActionData = ToDoAction.RequestBlankData();
            ToDoAction.SetActionData(ActionData);
        }
    }
    void SetupConditions()
    {
        foreach (Condition Con in InteractionConditions)
        {
            ConditionSetUpData ConData = Con.RequestBlankData();

            Con.SetConditionData(ConData);
        }
    }

    ////This will be a window that opens up when a new condtion is made... hard to implement here
    //void RequestCondtionsData()
    //{
    //    switch()
    //    {

    //    }
    //}
}
