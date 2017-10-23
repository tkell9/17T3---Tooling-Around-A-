using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Action : MonoBehaviour {

    public string ActionName;
    public bool HasActionCompleted;
    //public ActionSetupData ActionData;

    public abstract void UndertakeAction();
    public virtual void ResetAction()
    {
        if(HasActionCompleted)
        {
            HasActionCompleted = false;
        }
    }

    public abstract ActionSetupData RequestBlankData();
    public abstract void SetActionData(ActionSetupData data);
}