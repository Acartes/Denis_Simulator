using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempDatas : MonoBehaviour {

  public Vector3 moveTarget = Vector3.zero;
  public Vector3 playerPos;
  public Transform hoveredObj;
  public Transform selectedObj;
  public Transform takenObj;
  public bool gotObj = false;
  public MouseType mouseType;
}
public enum MouseType
{
  Null,
  Down,
  Slide,
  Click
}

