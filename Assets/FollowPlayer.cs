using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {
  public TempDatas TempDatas;

  Vector3 offset;
	
	// Update is called once per frame
	void FixedUpdate () {
    if (offset == Vector3.zero)
      offset = TempDatas.playerPos - transform.position;
    transform.position = TempDatas.playerPos - offset;
    }
}
