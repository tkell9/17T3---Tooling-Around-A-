using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class TextureOffset : MonoBehaviour {
    public bool staticMoving;
    public Vector2 movementDirection;
    public float movementSpeed;

    private MeshRenderer mr;

    private void Start()
    {
        mr = GetComponent<MeshRenderer>();
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
        foreach(Material mat in mr.materials)
        {
            mat.mainTextureOffset += movementDirection * movementSpeed * Time.deltaTime;
        }
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
