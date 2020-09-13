using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPlayerCollisionAmplifyVelocity : MonoBehaviour {

  Rigidbody rb;

  // Use this for initialization
  void Start () {
    rb = GetComponent<Rigidbody>();
	}

  void OnCollisionEnter(Collision collision)
  {
    if (collision.transform.name.Contains("Player"))
    {
      Debug.Log(collision.transform.name);
      rb.AddForceAtPosition((collision.transform.position - transform.position).normalized * 10, transform.position);
    }
    return;
  }
}
