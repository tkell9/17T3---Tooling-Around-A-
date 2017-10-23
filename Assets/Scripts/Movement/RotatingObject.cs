using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RotatingObject : MonoBehaviour {
    public bool staticMoving;
    public Vector3 rotateDirection;
    public float movementSpeed;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rotateDirection.Normalize();
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
        rb.angularVelocity = rotateDirection * movementSpeed;
    }

    public void SpeedChanged(SpeedChangedData data)
    {
        if (!staticMoving)
        {
            movementSpeed = data.newSpeed.magnitude;
            rotateDirection = data.newSpeed.normalized;
        }
    }
}
