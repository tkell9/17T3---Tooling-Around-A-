using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcePool : MonoBehaviour {

    public List<string> AvaliableResourcesList = new List<string>();
    public List<int> AvaliableResourceValueList = new List<int>();

    public Dictionary<string, float> AvaliableResources = new Dictionary<string, float>();

    private void Awake()
    {
        CheckValueIndex();
        ConstructResourceDictionary();
    }

    void ConstructResourceDictionary()
    {
        for(int ResIndex = 0; ResIndex < AvaliableResourcesList.Count; ResIndex++)
            AvaliableResources.Add(AvaliableResourcesList[ResIndex], AvaliableResourceValueList[ResIndex]);
    }

    void CheckValueIndex()
    {
        if(AvaliableResourceValueList.Count != AvaliableResourcesList.Count)
            for(int ResIndex = AvaliableResourceValueList.Count; ResIndex < AvaliableResourcesList.Count; ++ResIndex)
                AvaliableResourceValueList.Add(0);
    }
}
