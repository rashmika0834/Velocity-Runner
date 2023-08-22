using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{

    public Transform CenterOfMass;
    public float motorTorque = 100f;
    public float maxSteer = 20f;

    public float Steer { get; set; }
    public float Throttle { get; set; }
   
    private Rigidbody _rigidBody;

    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _rigidBody.centerOfMass = CenterOfMass.localPosition;
    }


    void Update()
    {

    }
}
