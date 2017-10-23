using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneAction : Action
{
    public LoadSceneData actionData;

    public override void UndertakeAction()
    {
        if (actionData == null)
        {
            return;
        }

        if(actionData.sceneName == "0")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
        }
        else
        {
            SceneManager.LoadScene(actionData.sceneName, LoadSceneMode.Single);
        }

        HasActionCompleted = true;
    }

    public override ActionSetupData RequestBlankData()
    {
        return new LoadSceneData();
    }

    public override void SetActionData(ActionSetupData data)
    {
        actionData = (LoadSceneData)data;
    }
}
