using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectOnTriggerEnter2DCondition : Condition {

    public bool HasObjectEntered;
    public ObjectOnTriggerEnter2DConditionSetupData Data;

    public override bool HasConditionBeenFulfilled()
    {
        if (HasObjectEntered)
        {
            return true;
        }
            
        return false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Data.ConcerningTags.Contains(collision.gameObject.tag))
            HasObjectEntered = true;
        else
            HasObjectEntered = false;
    }

  

    public override void ResetCondition()
    {
        HasObjectEntered = false;
    }

    public override ConditionSetUpData RequestBlankData()
    {
        return new ObjectOnTriggerEnter2DConditionSetupData();
    }

    public override void SetConditionData(ConditionSetUpData data)
    {
        throw new System.NotImplementedException();
    }

    //void ColliderSetup(ObjectOnTriggerEnter2DConditionSetupData _OTESetUpData)
    //{
    //    switch (_OTESetUpData.ObjectColider)
    //    {
    //        case ObjectOnTriggerEnter2DConditionSetupData.ColiderType.Box:
    //            BoxCollider2D ThisCollider = gameObject.GetComponent<BoxCollider2D>();
    //            if (ThisCollider == null)
    //            {
    //                ThisCollider = gameObject.AddComponent<BoxCollider2D>();
    //                ThisCollider.isTrigger = true;
    //            }
    //            else
    //            {
    //                if (ThisCollider.isTrigger == false)
    //                {
    //                    ThisCollider = gameObject.AddComponent<BoxCollider2D>();
    //                    ThisCollider.isTrigger = true;
    //                }
    //            }
    //            break;
    //        case ObjectOnTriggerEnter2DConditionSetupData.ColiderType.Sphere:
    //            break;
    //        case ObjectOnTriggerEnter2DConditionSetupData.ColiderType.Capsule:
    //            break;
    //    }
    //}


    ////This will be the create window editor.. maybe put this in it's own script... createdata class... or in ConditionSetupData
    //public override ObjectOnTriggerEnter2DConditionSetupData RequestDataSetup()
    //{
    //    ObjectOnTriggerEnter2DConditionSetupData ConData = ScriptableObject.CreateInstance<ObjectOnTriggerEnter2DConditionSetupData>();
    //    ConData.ConcerningTags.Add("Player");
    //    ConData.ObjectColider = ObjectOnTriggerEnter2DConditionSetupData.ColiderType.Box;

    //    return ConData;
    //}
}
