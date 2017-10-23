using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class ScrollingObject : MonoBehaviour {
    public bool staticMoving;
    public Vector3 movementDirection;
    public float movementSpeed;

    [Header("<1 = slower, ==1 base speed, >1 faster")]
    public float paralaxMultipler = 1;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        movementDirection.Normalize();
    }

    private void OnEnable()
    {
        GlobalEvents.speedChanged.AddListener(SpeedChanged);
    }

    private void OnDisable()
    {
        GlobalEvents.speedChanged.RemoveListener(SpeedChanged);
    }

    private void FixedUpdate()
    {
        float tempVar = movementSpeed;
        tempVar *= paralaxMultipler;

        rb.velocity = movementDirection * tempVar;
    }

    public void SpeedChanged(SpeedChangedData data)
    {
        if (!staticMoving)
        {
            movementSpeed = data.newSpeed.magnitude;
            movementDirection = data.newSpeed.normalized;
        } 
    }

}
