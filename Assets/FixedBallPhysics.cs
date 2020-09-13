using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedBallPhysics : MonoBehaviour {

  Rigidbody rb;
  float scaler = 0.1f;

  void Start()
  {
    rb = GetComponent<Rigidbody>();
    rb.sleepThreshold = 0.01f;
  }

  void FixedUpdate()
  {
    //Debug.Log(rb.angularVelocity.x + " : " + rb.angularVelocity.y + " : " + rb.angularVelocity.z);
    rb.inertiaTensorRotation = new Quaternion(0.01f, 0.01f, 0.01f, 1);
    rb.AddTorque(-rb.angularVelocity * scaler);
  }
}
